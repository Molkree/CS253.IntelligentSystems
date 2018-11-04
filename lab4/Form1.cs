using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class Form1 : Form
    {
        List<Fact> given_facts = new List<Fact>();
        List<Fact> all_facts = new List<Fact>();
        List<Terminal> terminals = new List<Terminal>();
        List<Rule> rules = new List<Rule>();
        static FactComparer cmp = new FactComparer();

        HashSet<Fact> known_facts = new HashSet<Fact>(cmp);

//        List<Fact> known_facts = new List<Fact>(); // proven facts
        List<Fact> support_area = new List<Fact>(); // non terminal
            
        //private List<Fact> possible_knoweledge = new List<Fact>(); //all facts that users can change
        //private List<TerminalFact> terminals = new List<TerminalFact>(); // terminal facts
        //private List<Rule> Rules = new List<Rule>();
        //private HashSet<Fact> work_area = new HashSet<Fact>(); // proven facts
        //private HashSet<Fact> support_area = new HashSet<Fact>();  // non terminal 
        public Form1()
        {
            InitializeComponent();
            read_data("../../database.txt");
            init_listbox();
        }

        public void read_data(string filename)
        {
            List<string> lines = System.IO.File.ReadLines(filename, Encoding.UTF8).ToList();
            
            // f
            var str = lines[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int facts_cnt = Int32.Parse(str[0]);
            for (int i = 1; i < facts_cnt + 1; ++i)
            {
                str = lines[i].Split(new char[] { ':', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                Fact f = new Fact(str[0].Trim(), str[1]);
                all_facts.Add(f);
            }

            // s
            str = lines[facts_cnt + 1].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int support_cnt = Int32.Parse(str[0]);
            int n = facts_cnt + support_cnt + 1;
            for (int i = facts_cnt + 2; i < n; ++i)
            {
                str = lines[i].Split(new char[] { ':', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                all_facts.Add(new Fact(str[0].Trim(), str[1]));
            }

            // t
            str = lines[n].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int term_cnt = Int32.Parse(str[0]);
            n += 1;
            for (int i = n; i < n + term_cnt; ++i)
            {
                str = lines[i].Split(new char[] { ':', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                all_facts.Add(new Terminal(str[0].Trim(), str[1]));
                terminals.Add(new Terminal(str[0].Trim(), str[1]));
            }

            // r
            n += term_cnt;
            str = lines[n].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int rules_cnt = Int32.Parse(str[0]);
            for (int i = n + 1; i < n + rules_cnt; ++i)
            {
                str = lines[i].Split(new char[] { ':', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                string id = str[0].Trim();

                // condition
                var fact_str = str[1].Split(new char[] { ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                List<Fact> cond = new List<Fact>();
                for (int j = 0; j < fact_str.Count(); ++j)
                {
                    string index = fact_str[j].Trim();
                    Fact fact = all_facts.Find(f => f.id.Equals(index));

                    if (fact.id != "") // exists
                        cond.Add(fact);
                }

                // result
                fact_str = str[2].Split(new char[] { ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                Fact res = all_facts.Find(f => f.id.Equals(fact_str[0].Trim()));

                if (res.id != "") // exists
                {
                    rules.Add(new Rule(id, cond, res));
                }


            }
        }

        public void init_listbox()
        {
            foreach (Fact f in all_facts)
            {
                if (f.id[0] != 'f')
                    break;
                list_villains.Items.Add(f.info);
            }
        }

        private void button_exec_Click(object sender, EventArgs e)
        {
            foreach (int ind in list_villains.SelectedIndices)
            {
                Fact fact = all_facts.Find(f => f.info == (list_villains.Items[ind]).ToString());
                if (fact.id != "")
                {
                    given_facts.Add(fact);
                }
            }
            label_heros.Text = "";

            if (check_forward.Checked)
                forward_reasoning();
            else
                backward_reasoning();
        }

        public void forward_reasoning()
        {
            foreach (Fact fact in given_facts)
                known_facts.Add(fact);

            while (true)
            {
                int prev_cnt = known_facts.Count;
                foreach (Rule r in rules)
                {
                    bool cond = true;
                    foreach (Fact f in r.condition)
                        if (!known_facts.Contains(f, cmp))
                        {
                            cond = false;
                            break;
                        }
                    if (cond)
                    {
                        known_facts.Add(r.result);
                    }
                }
                if (prev_cnt == known_facts.Count)
                    break;
            }

            foreach (Fact f in known_facts)
            {
                if (f.id[0] == 't')
                    label_heros.Text += f.info + "\n";
            }

        
        }

        public void backward_reasoning()
        {
            

  /*          HashSet<Fact> targets = new HashSet<Fact>(cmp);
            foreach (Fact fact in terminals)
            {
                targets.Add(fact);
            }

            //foreach (Fact fact in terminals)
            //    known_facts.Add(fact);

            while (true)
            {
                foreach (Rule r in rules)
                {
                    if (targets.Contains(r.result, cmp))
                    {
                        foreach (Fact cond in r.condition)
                        {
                            if (!known_facts.Contains(cond, cmp))
                                targets.Add(cond);
                        }

                    }
                }
            }*/
        }

    }

    public class Fact
    {
        public string id = "";
        public string info = "";

        public Fact() { }

        public Fact(string id, string info)
        {
            this.id = id.Trim();
            this.info = info;
        }

    /*    public bool Equals(Fact obj)
        {
            if (obj == null) return false;
            return id.Equals(obj.id);
        }*/
    }

    public class FactComparer : IEqualityComparer<Fact>
    {

        public bool Equals(Fact f1, Fact f2)
        {
            return (f1.id.Equals(f2.id));
        }

        public int GetHashCode(Fact f)
        {
            return f.id.GetHashCode() ^ f.info.GetHashCode();
        }
    }

    public class Terminal: Fact
    {
        public Terminal() { }

        public Terminal(string id, string info)
        {
            this.id = id.Trim();
            this.info = info;
        }
    }

    public class Rule
    {
        public string id = "";
        public List<Fact> condition;
        public Fact result;
        public string info = "";

        public Rule()
        {
            condition = new List<Fact>();
            result = new Fact();          
        }
        public Rule(string id, List<Fact> cond, Fact res)
        {
            this.id = id;
            condition = new List<Fact>(cond);
            result = res;

            info = id + ": " + string.Join(", ", condition.Select(f => f.info)) + " => " + string.Join(", ", res.info);
        }

   /*     public bool Equals(Rule obj)
        {
            if (obj == null) return false;
            return id.Equals(obj.id);
        }*/
    }
    public class RuleComparer : IEqualityComparer<Rule>
    {

        public bool Equals(Rule r1, Rule r2)
        {
            return (r1.id.Equals(r2.id));
        }

        public int GetHashCode(Rule r)
        {
            return r.id.GetHashCode() ^ r.info.GetHashCode();
        }
    }

    class Node
    {
        public List<Node> parents = new List<Node>();
        public List<Node> children = new List<Node>();

        public Node() { }
    }

    class AndNode: Node
    {
        public Rule r = new Rule();
        public AndNode() { }
        public AndNode(Rule rule)
        {
            r = rule;
        }
    }

    class OrNode : Node
    {
        public Fact f = new Fact();
        public OrNode() { }
        public OrNode(Fact fact)
        {
            f = fact;
        }
    }
}
