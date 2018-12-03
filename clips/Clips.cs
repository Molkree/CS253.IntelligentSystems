using System;
using System.Collections.Generic;
using System.Globalization;
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
            int facts_cnt = int.Parse(str[0], CultureInfo.InvariantCulture);
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
            int support_cnt = int.Parse(str[0], CultureInfo.InvariantCulture);
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
            int term_cnt = int.Parse(str[0], CultureInfo.InvariantCulture);
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
            int rules_cnt = int.Parse(str[0], CultureInfo.InvariantCulture);
            clp = "";
            for (int i = n + 1; i < n + rules_cnt + 1; ++i)
            {
                string rule = "";
                str = lines[i].Split(new char[] { ':', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                string rule_id = str[0].Trim();
                rule += "(defrule " + rule_id + "\n";
                rule += "    (declare (salience 99))\n";

                // condition
                var fact_str = str[1].Split(new char[] { ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                var condition_list = new List<string>();
                for (int j = 0; j < fact_str.Count(); ++j)
                {
                    string index = fact_str[j].Trim();
                    // villain
                    if (index[0] == 'f')
                        rule += "    (villain (id " + index + "))\n";
                    // trait
                    else
                    {
                        condition_list.Add(index);
                        rule += "    (trait (id " + index + ") (possibility ?" + index + "-coef))\n";
                    }
                }

                // read rule possibility
                var strc = str[3].Trim();
                double coef = double.Parse(strc, new CultureInfo("us"));

                // result
                fact_str = str[2].Split(new char[] { ',', '\t' }, StringSplitOptions.RemoveEmptyEntries); // why array? if we decide to give list of resulting facts
                string id = fact_str[0].Trim();

                // trait
                if (id[0] == 's')
                {
                    var trait = db_clips.FindFact("?t", "trait", "(= (str-compare ?t:id " + id + ") 0)");
                    byte[] bytes = Encoding.Default.GetBytes(((LexemeValue)trait["name"]).Value);
                    string first_occurence = string.Copy(rule);
                    first_occurence = first_occurence.Insert(first_occurence.IndexOf('\n'), "f"); // modify rule id
                    first_occurence += "    (not (trait (id " + id + ")))\n";
                    first_occurence += "    =>\n";
                    first_occurence += "    (assert (trait (id " + id + ") (name \"" + Encoding.UTF8.GetString(bytes) + "\") (possibility (* ";
                    // calculate min possibility of conditions
                    first_occurence += "(min 1";
                    foreach (var cond in condition_list)
                        first_occurence += " ?" + cond + "-coef";
                    first_occurence += ") " + coef.ToString() + "))))\n";
                    first_occurence += ")\n\n";
                    clp += first_occurence;
                    rule += "    (trait (id " + id + ") (possibility ?old-coef))\n";
                    rule += "    (not (already-increased (id t" + rule_id + ")))\n";
                    rule += "    ?t <- (trait (id " + id + "))\n";
                    rule += "    =>\n";
                    rule += "    (modify ?t (possibility (max ?old-coef (* ";
                    // calculate min possibility of conditions
                    rule += "(min 1";
                    foreach (var cond in condition_list)
                        rule += " ?" + cond + "-coef";
                    rule += ") " + coef.ToString() + "))))\n";
                    rule += "    (assert (already-increased (id t" + rule_id + ")))\n";
                }
                // hero
                else
                {
                    var hero = db_clips.FindFact("?h", "hero", "(= (str-compare ?h:id " + id + ") 0)");
                    byte[] bytes = Encoding.Default.GetBytes(((LexemeValue)hero["name"]).Value);
                    string first_occurence = string.Copy(rule);
                    first_occurence = first_occurence.Insert(first_occurence.IndexOf('\n'), "f"); // modify rule id
                    first_occurence += "    (not (hero (id " + id + ")))\n";
                    first_occurence += "    =>\n";
                    first_occurence += "    (assert (hero (id " + id + ") (name \"" + Encoding.UTF8.GetString(bytes) + "\") (count 1) (possibility (* ";
                    // calculate min possibility of conditions
                    first_occurence += "(min 1";
                    foreach (var cond in condition_list)
                        first_occurence += " ?" + cond + "-coef";
                    first_occurence += ") " + coef.ToString() + "))))\n";
                    first_occurence += ")\n\n";
                    clp += first_occurence;
                    rule += "    (hero (id " + id + ") (count ?cnt) (possibility ?old-coef))\n";
                    rule += "    (not (already-increased (id h" + rule_id + ")))\n";
                    rule += "    ?h <- (hero (id " + id + "))\n";
                    rule += "    =>\n";
                    rule += "    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* ";
                    // calculate min possibility of conditions
                    rule += "(min 1";
                    foreach (var cond in condition_list)
                        rule += " ?" + cond + "-coef";
                    rule += ") " + coef.ToString() + "))))\n";
                    rule += "    (assert (already-increased (id h" + rule_id + ")))\n";
                }

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

            textBox1.Text = "";
            for (int i = 0; i < damf.Count; i++)
            {
                LexemeValue da = (LexemeValue)damf[i];
                byte[] bytes = Encoding.Default.GetBytes(da.Value);
                textBox1.Text += Encoding.UTF8.GetString(bytes) + System.Environment.NewLine;
            }

            clips.Eval("(assert (clearmessage))");
        }

        public void InitListbox()
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
            InitListbox();
        }

        private void fontSelect_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
            }
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
            if (!checkBox1.Checked)
            {
                clips.AssertString("(team-size (count " + list_villains.SelectedIndices.Count.ToString(CultureInfo.InvariantCulture) + "))");
            }
            else
            {
                clips.AssertString("(team-size (count " + (-list_villains.SelectedIndices.Count).ToString(CultureInfo.InvariantCulture) + "))");
            }

            clips.Run();
            HandleResponse();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            GenerateCLIPSFiles();
        }
    }
}