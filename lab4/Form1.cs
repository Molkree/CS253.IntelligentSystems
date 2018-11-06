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

        Dictionary<Fact, int> known_facts = new Dictionary<Fact, int>(cmp);
    //    HashSet<Fact> known_facts = new HashSet<Fact>(cmp);

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
            int n = facts_cnt + support_cnt + 2;
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
                    
                    if (fact != null && fact.id != "") // exists
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
            given_facts.Clear();
            known_facts.Clear();
            label_heroes.Text = "";
            list_info.Items.Clear();
            terminals.Clear();

            foreach (int ind in list_villains.SelectedIndices)
            {
                Fact fact = all_facts.Find(f => f.info == (list_villains.Items[ind]).ToString());
                if (fact != null && fact.id != "")
                {
                    given_facts.Add(fact);
                }
            }
            label_heroes.Text = "";

            if (check_forward.Checked)
                forward_reasoning();
            else
                backward_reasoning();
                
         
        }

        public void forward_reasoning_all_rules()
        {
            foreach (Fact fact in given_facts)
            {
                if (known_facts.ContainsKey(fact))
                    known_facts[fact] += 1;
                else known_facts.Add(fact, 1);
            }
            //                known_facts[fact] += 1;
            //                known_facts.Add(fact);

            while (true)
            {
                int prev_cnt = known_facts.Count;
                foreach (Rule r in rules)
                {
                    bool cond = true;
                    foreach (Fact f in r.condition)
                        if (!known_facts.ContainsKey(f))
                        {
                            cond = false;
                            break;
                        }
                    if (cond)
                    {
                        if (known_facts.ContainsKey(r.result))
                            known_facts[r.result] += 1;
                        else
                        {
                            known_facts.Add(r.result, 1);
                            list_info.Items.Add(r.info);
                        }
                        //                        known_facts.Add(r.result);
                    }
                }
                if (prev_cnt == known_facts.Count)
                    break;
            }

            Dictionary<Fact, int> terms = new Dictionary<Fact, int>();
            foreach (var p in known_facts)
            {
                if (p.Key.id[0] == 't')
                    terms[p.Key] = p.Value;
            }

            /*           for (int i = 0; i < given_facts.Count; ++i)
                       {
                           var p = terms.Aggregate((x, y) => (x.Value > y.Value) ? x : y);
                           label_heros.Text += p.Key.info + "\n";
                           terms.Remove(p.Key);
                       }*/
            for (int i = 0; i < given_facts.Count; ++i)
            {

                var p = terms.Values.Max();
                foreach (var t in terms)
                    if (t.Value == p)
                    {
                        label_heroes.Text += t.Key.info + "\n";
                        terms.Remove(t.Key);
                        break;
                    }


            }

            /*            foreach (Fact f in known_facts)
                        {
                            if (f.id[0] == 't')
                                label_heros.Text += f.info + "\n";
                        }
                        */

        }

        // для каждого факта - отдельно
        public void forward_reasoning()
        {
            List<Fact> result = new List<Fact>();

            foreach (Fact fact in given_facts)
            {
                known_facts.Add(fact, 1);

                // check rules
                while (true)
                {
                    int prev_cnt = known_facts.Count;
                    foreach (Rule r in rules)
                    {
                        bool cond = true;
                        foreach (Fact f in r.condition)
                            if (!known_facts.ContainsKey(f))
                            {
                                cond = false;
                                break;
                            }
                        if (cond)
                        {
                            if (known_facts.ContainsKey(r.result))
                                known_facts[r.result] += 1;
                            else
                            {
                                known_facts.Add(r.result, 1);
                                list_info.Items.Add(r.info);
                            }
                        }
                    }
                    if (prev_cnt == known_facts.Count)
                        break;
                }

                // find terminal facts
                Dictionary<Fact, int> terms = new Dictionary<Fact, int>();
                foreach (var p in known_facts)
                {
                    if (p.Key.isTerminal())
                        terms[p.Key] = p.Value;
                }

                // in order not to repeat heroes
                while (terms.Count != 0)
                {
                    var term1 = terms.Aggregate((x, y) => (x.Value > y.Value) ? x : y);
                    if (!result.Contains(term1.Key, cmp))
                    {
                        label_heroes.Text += term1.Key.info + "\n";
                        result.Add(term1.Key);
                        break;
                    }
                    else
                        terms.Remove(term1.Key);
                }
                known_facts.Clear();
            }         
        }

        private void resolve(Node n)
        {
            if (n.flag)
                return;
            if (n is AndNode)
                n.flag = n.children.All(c => c.flag == true);

            if (n is OrNode)
                n.flag = n.children.Any(c => c.flag == true);

            if (n.flag)
            {
                foreach (Node p in n.parents)
                    resolve(p);
            }
        }

        public void backward_reasoning()
        {
            Dictionary<Terminal, int> res = new Dictionary<Terminal, int>();

            HashSet<Fact> known_facts_set = new HashSet<Fact>(cmp);
//            known_facts.Clear();
            foreach (Fact fact in given_facts)
            {
                known_facts_set.Add(fact);
            }

            HashSet<Fact> targets = new HashSet<Fact>(cmp);

//            Node tree = new Node();

            // check all terminals
            foreach (Fact term in all_facts)
               if (term.isTerminal())
                {
                    Dictionary<Rule, AndNode> and_dict = new Dictionary<Rule, AndNode>();
                    Dictionary<Fact, OrNode> or_dict = new Dictionary<Fact, OrNode>();
                    OrNode root = new OrNode(term);
                    or_dict.Add(term, root);

                    Stack<Node> tree = new Stack<Node>();
                    tree.Push(root);
                    while (tree.Count != 0)
                    {
                        Node current = tree.Pop();
                        if (current is AndNode)
                        {
                            AndNode and_node = current as AndNode;
                            foreach (Fact f in and_node.r.condition)
                            {
                                if (or_dict.ContainsKey(f))
                                {
                                    current.children.Add(or_dict[f]);
                                    or_dict[f].parents.Add(current);
                                }
                                else
                                {
                                    or_dict.Add(f, new OrNode(f));
                                    and_node.children.Add(or_dict[f]);
                                    or_dict[f].parents.Add(and_node);
                                    tree.Push(or_dict[f]);
                                }
                            }
                        }
                        else // current is OrNode
                        {
                            OrNode or_node = current as OrNode;
                            foreach (Rule rule in rules.Where(r => r.result.Equals(or_node.f)))
                                if (and_dict.ContainsKey(rule))
                                {
                                    current.children.Add(and_dict[rule]);
                                    and_dict[rule].parents.Add(current);
                                }
                                else
                                {
                                    and_dict.Add(rule, new AndNode(rule));
                                    or_node.children.Add(and_dict[rule]);
                                    and_dict[rule].parents.Add(or_node);
                                    tree.Push(and_dict[rule]);
                                }
                        }
                    }

                    int cnt = 0;
                    foreach (var f in or_dict)
                    {
                        if (given_facts.Contains(f.Key))
                            ++cnt;
                    }

                    foreach (var val in or_dict)
                        if (given_facts.Contains(val.Key))
                        {
                            val.Value.flag = true;
                            foreach (Node p in val.Value.parents)
                                resolve(p);
                            if (root.flag == true)
                            {
                                label_heroes.Text += root.f.info + "\n";

                                Node n = root;
                                while (n.children.Count != 0)
                                {
                                    n = n.children[0];
                                    if (n is AndNode)
                                        list_info.Items.Add((n as AndNode).r.info);
                                    else continue;
                                }
                                
                                //
 //                               res.Add(root.f as Terminal, cnt);
                                break;
                            }
                        }


                    //     targets.Add(term);
                    /*
                                        foreach (Rule r in rules)
                                        {
                                            // check hypotheses
                                            foreach (Fact h in targets)
                                            {
                                                if (h.Equals(r.result))
                                                {
                                                    bool cond = true;
                                                    foreach (Fact c in r.condition)
                                                        if (!known_facts_set.Contains(c))
                                                        {
                                                            cond = false;
                                                            targets.Add(c);
                                                        }
                                                    if (cond)
                                                    {
                                                        targets.Remove(h);
                                                        known_facts_set.Add(h);
                                                    }
                                                }

                                            }

                                        }*/

                    //     targets.Clear();
                    
                }
            
            if (res.Count != 0)
            {
                Terminal best = res.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
                label_heroes.Text += best.info + "\n";
                //  pictureBox1.ImageLocation = best.img;
            }


            /*          
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

        private void button_clear_Click(object sender, EventArgs e)
        {
            given_facts.Clear();
            known_facts.Clear();
            terminals.Clear();
            list_villains.SelectedIndices.Clear();
            label_heroes.Text = "Никого...";
            list_info.Items.Clear();
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
        //    if (id[0] == 't')
        //        isTerminal = true;
        }
        public bool isTerminal()
        {
            return id[0] == 't';
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
        public bool flag = false;
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
