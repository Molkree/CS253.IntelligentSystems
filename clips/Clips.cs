﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CLIPSNET;

namespace ClipsFormsExample
{
    public partial class ClipsMatchmaking : Form
    {
        private CLIPSNET.Environment db_clips = new CLIPSNET.Environment();
        private CLIPSNET.Environment clips = new CLIPSNET.Environment();

        public ClipsMatchmaking()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadDatabase();
        }

        private void GenerateCLIPSFiles()
        {
            List<string> lines = System.IO.File.ReadLines("../../../database.txt", Encoding.UTF8).ToList();

            // Villains
            var str = lines[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int facts_cnt = int.Parse(str[0]);
            var clp = "(deftemplate villain\n    (slot id)\n    (slot name)\n)\n\n(deffacts villains\n";
            for (int i = 1; i < facts_cnt + 1; ++i)
            {
                str = lines[i].Split(new char[] { ':', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                clp += "    (villain (id " + str[0].Trim() + ") (name \"" + str[1].Trim() + "\"))\n";
            }
            clp += ")";
            System.IO.File.WriteAllText("../../../villains.clp", clp);

            // Traits
            str = lines[facts_cnt + 1].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int support_cnt = int.Parse(str[0]);
            int n = facts_cnt + support_cnt + 2;
            clp = "(deftemplate trait\n    (slot id)\n    (slot name)\n)\n\n(deffacts traits\n";
            for (int i = facts_cnt + 2; i < n; ++i)
            {
                str = lines[i].Split(new char[] { ':', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                clp += "    (trait (id " + str[0].Trim() + ") (name \"" + str[1].Trim() + "\"))\n";
            }
            clp += ")";
            System.IO.File.WriteAllText("../../../traits.clp", clp);

            // Heroes
            str = lines[n].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int term_cnt = int.Parse(str[0]);
            n += 1;
            clp = "(deftemplate hero\n    (slot id)\n    (slot name)\n)\n\n(deffacts heroes\n";
            for (int i = n; i < n + term_cnt; ++i)
            {
                str = lines[i].Split(new char[] { ':', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                clp += "    (hero (id " + str[0].Trim() + ") (name \"" + str[1].Trim() + "\"))\n";
            }
            clp += ")";
            System.IO.File.WriteAllText("../../../heroes.clp", clp);

            // Rules
            n += term_cnt;
            str = lines[n].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int rules_cnt = int.Parse(str[0]);
            clp = "";
            for (int i = n + 1; i < n + rules_cnt + 1; ++i)
            {
                string rule = "";
                str = lines[i].Split(new char[] { ':', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                string id = str[0].Trim();
                rule += "(defrule " + id + "\n";

                // condition
                var fact_str = str[1].Split(new char[] { ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < fact_str.Count(); ++j)
                {
                    string index = fact_str[j].Trim();
                    // villain
                    if (index[0] == 'f')
                        rule += "    (villain (id " + index + "))\n";
                    // trait
                    else
                        rule += "    (trait (id " + index + "))\n";
                }

                // result
                fact_str = str[2].Split(new char[] { ',', '\t' }, StringSplitOptions.RemoveEmptyEntries); // why array? if we decide to give list of resulting facts
                id = fact_str[0].Trim();
                // trait
                if (id[0] == 's')
                {
                    rule += "    =>\n";
                    var trait = db_clips.FindFact("?t", "trait", "(= (str-compare ?t:id " + id + ") 0)");
                    byte[] bytes = Encoding.Default.GetBytes(((LexemeValue)trait["name"]).Value);
                    rule += "    (assert (trait (name \"" + Encoding.UTF8.GetString(bytes) + "\") (id " + id + ")))\n";
                }
                // hero
                else
                {
                    var hero = db_clips.FindFact("?h", "hero", "(= (str-compare ?h:id " + id + ") 0)");
                    byte[] bytes = Encoding.Default.GetBytes(((LexemeValue)hero["name"]).Value);
                    string first_occurence = string.Copy(rule);
                    first_occurence = first_occurence.Insert(first_occurence.IndexOf('\n'), "f"); // modify rule id
                    first_occurence += "    (not (exists (hero (id " + id + "))))\n";
                    first_occurence += "    =>\n";
                    first_occurence += "    (assert (hero (id " + id + ") (name \"" + Encoding.UTF8.GetString(bytes) + "\") (count 0)))\n";
                    first_occurence += ")\n\n";
                    clp += first_occurence;
                    rule += "    (exists (hero (id " + id + ")))\n";
                    rule += "    ?h <- (hero (id " + id + "))\n";
                    rule += "    (bind ?old_count ?h:count)\n";
                    rule += "    =>\n";
                    //rule += "    (assert (sendmessagehalt \"Ага!!!!!!!!\"))\n";
                    rule += "    (modify ?h (count (+ ?old_count 1)))\n";
                }

                // without coefficients for now
                //var strc = str[3].Trim();
                //double coef = double.Parse(strc, new CultureInfo("us"));
                rule += ")\n\n";
                clp += rule;
            }
            System.IO.File.WriteAllText("../../../rules_tmp.clp", clp);
        }

        private void HandleResponse()
        {
            //  Вытаскиаваем факт из ЭС
            FactAddressValue fv = clips.FindFact("ioproxy");

            MultifieldValue damf = (MultifieldValue)fv["messages"];
            MultifieldValue vamf = (MultifieldValue)fv["answers"];

            textBox1.Text += "Новая итерация : " + System.Environment.NewLine;
            for (int i = 0; i < damf.Count; i++)
            {
                LexemeValue da = (LexemeValue)damf[i];
                byte[] bytes = Encoding.Default.GetBytes(da.Value);
                textBox1.Text += Encoding.UTF8.GetString(bytes) + System.Environment.NewLine;
            }

            if (vamf.Count > 0)
            {
                textBox1.Text += "----------------------------------------------------" + System.Environment.NewLine;
                for (int i = 0; i < damf.Count; i++)
                {

                    LexemeValue va = (LexemeValue)vamf[i];
                    textBox1.Text += va.Value + System.Environment.NewLine;
                }
            }

            clips.Eval("(assert (clearmessage))");
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            label1.Text = clips.Run().ToString();
            HandleResponse();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            //clips.Clear();

            ///*string stroka = codeBox.Text;
            //System.IO.File.WriteAllText("tmp.clp", codeBox.Text);
            //clips.Load("tmp.clp");*/

            ////  Так тоже можно - без промежуточного вывода в файл
            ////clips.LoadFromString(codeBox.Text);
            //clips.LoadFromString(System.IO.File.ReadAllText("../../../rules.clp"));

            //clips.Reset();

            ////init_listbox();
            //textBox1.Text = "Выполнены команды Clear и Reset." + System.Environment.NewLine;
        }

        public void init_listbox()
        {
            var villains = db_clips.FindAllFacts("villain");
            foreach (var v in villains)
            {
                byte[] bytes = Encoding.Default.GetBytes(((LexemeValue)v["name"]).Value);
                list_villains.Items.Add(Encoding.UTF8.GetString(bytes));
            }
        }

        private void LoadDatabase()
        {
            db_clips.Clear();
            db_clips.LoadFromString(System.IO.File.ReadAllText("../../../villains.clp"));
            db_clips.LoadFromString(System.IO.File.ReadAllText("../../../traits.clp"));
            db_clips.LoadFromString(System.IO.File.ReadAllText("../../../heroes.clp"));
            db_clips.Reset();
            init_listbox();
            codeBox.Text = System.IO.File.ReadAllText("../../../traits.clp");
        }

        private void openFile_Click(object sender, EventArgs e)
        {
        }

        private void fontSelect_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                codeBox.Font = fontDialog1.Font;
                textBox1.Font = fontDialog1.Font;
            }
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            //clipsSaveFileDialog.FileName = clipsOpenFileDialog.FileName;
            //if (clipsSaveFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    System.IO.File.WriteAllText(clipsSaveFileDialog.FileName, codeBox.Text);
            //}
        }

        private void button_exec_Click(object sender, EventArgs e)
        {
            clips.Clear();
            clips.LoadFromString(System.IO.File.ReadAllText("../../../templates.clp"));

            string villains = "(deftemplate villain\n    (slot id)\n    (slot name)\n)\n\n(deffacts villains\n";
            foreach (int ind in list_villains.SelectedIndices)
            {
                villains += " (villain (id f" + (ind + 1) + ") (name \"" + list_villains.Items[ind].ToString() + "\"))";
            }
            villains += ")";
            System.IO.File.WriteAllText("tmp.clp", villains);
            clips.LoadFromString(System.IO.File.ReadAllText("tmp.clp"));

            clips.LoadFromString(System.IO.File.ReadAllText("../../../rules_tmp.clp"));
            clips.LoadFromString(System.IO.File.ReadAllText("../../../rules.clp"));
            
            clips.Reset();
            textBox1.Text = "Выполнены команды Clear и Reset." + System.Environment.NewLine;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            GenerateCLIPSFiles();
        }
    }
}