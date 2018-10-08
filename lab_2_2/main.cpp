#include <vector>
#include <iostream>
#include <unordered_set>
#include <queue>
#include <ctime>
#include <list>
#include <algorithm>
#include <string>
using std::vector;
using std::pair;

struct Node
{
	Node* parent = nullptr;
	vector<pair<char, char>> field;
	bool solved = false;
	bool sb_is_eaten = false;
	char boat;
	int w_cnt, g_cnt, c_cnt;

	Node(Node* p, const vector<pair<char, char>> & f, char b, int w_cnt = 1, int g_cnt = 1, int c_cnt = 1)
	{
		parent = p;
		boat = b;
		field = vector<pair<char, char>>(f);
		std::sort(field.begin(), field.end());

		this->w_cnt = w_cnt;
		this->g_cnt = g_cnt;
		this->c_cnt = c_cnt;
		is_solved();
		is_eaten();
	}

	std::string print()
	{
		std::string res = "[";
		bool f = false;
		for (auto el : field)
		{
			if (!f && el.first == 'r')
			{
				res += "|";
				if (boat == 'l')
					res += "(boat)_______|";
				else res += "_______(boat)|";
				f = true;
			}
			res += el.second;
		}
		if (!f)
		{
			res += "|(boat)_______|";
		}
		res += ']';
		return res;
	}

private:
	void is_solved()
	{
		for (auto it : field)
			if (it.first != 'r')
			{
				solved = false;
				return;
			}
		solved = true;
	}

	void is_eaten()
	{
		int l_w = 0, l_g = 0, l_c = 0;
		for (auto it : field)
		{
			if (it.first != 'l') break;
			switch (it.second)
			{
			case 'w': ++l_w;
				break;
			case 'g': ++l_g;
				break;
			case 'c': ++l_c;
				break;
			default:
				break;
			}
		}
		int r_w = w_cnt - l_w;
		int r_g = g_cnt - l_g;
		int r_c = c_cnt - l_c;

		if (boat == 'l')
		{
			if ((r_g && r_w >= r_g) || (r_c && r_g >= r_c))
				sb_is_eaten = true;
			else sb_is_eaten = false;
		}
		else
		{
			if ((l_g && l_w >= l_g) ||	(l_c && l_g >= l_c))
				sb_is_eaten = true;
			else sb_is_eaten = false;
		}
	}
};

auto node_hash = [](Node* node) 
{
	std::size_t seed = node->field.size();
	for (auto &i : node->field)
		seed ^= (i.first - 'a' + i.second - 'a') + 0x9e3779b9 + (seed << 6) + (seed >> 2);
	return seed;
};

auto eq = [](Node* n1, Node* n2)
{
	if (n1->boat != n2->boat)
		return false;
	for (int i = 0; i < n2->field.size(); ++i)
	{
		if (n1->field[i] != n2->field[i])
			return false;
	}

	return true;
};

std::list<Node*> all_children(Node* start)
{
	std::list<Node*> res;
	char new_boat = start->boat == 'l' ? 'r' : 'l';
	res.push_back(new Node(start, start->field, new_boat, start->w_cnt, start->g_cnt, start->c_cnt));
	vector<pair<char, char>> new_f(start->field);
	for (int i = 0; i < new_f.size(); ++i)
	{
		if (new_f[i].first != start->boat)
			continue;
		new_f[i].first = new_boat;
		Node * ch = new Node(start, new_f, new_boat, start->w_cnt, start->g_cnt, start->c_cnt);
		res.push_back(ch);
		new_f[i].first = start->boat;
	}
	return res;
}

void bfs(Node* f)
{
	std::unordered_set<Node*, decltype(node_hash), decltype(eq)> used(100, node_hash, eq);
	used.insert(f);
	std::queue<Node*> q;
	q.push(f);

	Node* answ = nullptr;

	while (!q.empty())
	{
		Node* n = q.front();
		q.pop();
		if (n->solved)
		{
			answ = n;
			break;
		}

		auto chlds = all_children(n);
		for (auto c : chlds)
		{
			if (c->sb_is_eaten || used.find(c) != used.end())
			{
				delete c;
				continue;
			}
			
			q.push(c);
			used.insert(c);
		}
	}

	if (answ == nullptr)
		std::cout << "There's no answer :(\n";
	else
	{
		std::list<Node*> res;
		while (answ != nullptr)
		{
			res.push_front(answ);
			answ = answ->parent;
		}
		while (!res.empty())
		{
			auto tmp = res.front();
			res.pop_front();
			std::cout << tmp->print() << "\n";
		}
	}

/*	while (!q.empty())
	{
		auto tmp = q.front();
		q.pop();
		tmp->parent = nullptr;
		delete tmp;
	}
	for (auto el : used)
	{
		el->parent = nullptr;
		delete el;
	}*/
}

std::unordered_set<Node*, decltype(node_hash), decltype(eq)> dfs_used(100, node_hash, eq);
bool found_answ = false;

void dfs(Node* f)
{
	if (found_answ)
		return;
	if (f->solved)
	{
		std::list<Node*> res;
		while (f != nullptr)
		{
			res.push_front(f);
			f = f->parent;
		}
		while (!res.empty())
		{
			auto tmp = res.front();
			res.pop_front();
			std::cout << tmp->print() << "\n";
		}
		found_answ = true;
		return;
	}
	dfs_used.insert(f);
	auto ch = all_children(f);
	for (auto el : ch)
	{
		if (!el->sb_is_eaten && dfs_used.find(el) == dfs_used.end())
			dfs(el);
	}

}

bool DLS(Node* f, int depth, int limit)
{
	if (depth < limit)
	{
		if (f->solved)
		{
			std::list<Node*> res;
			while (f != nullptr)
			{
				res.push_front(f);
				f = f->parent;
			}
			while (!res.empty())
			{
				auto tmp = res.front();
				res.pop_front();
				std::cout << tmp->print() << "\n";
			}
			return true;
		}

		auto chl = all_children(f);
		for (auto& el : chl)
		{
			if (!el->sb_is_eaten)
				if (DLS(el, depth + 1, limit))
					return true;
		}
	}
	return false;
}

void ids(Node* f)
{
	int lim = 0;
	while (!DLS(f, 0, lim))
	{
		++lim;
		if (lim == 1000)
			break;
	}

	if (lim == 1000)
	{
		std::cout << "There is no answer :(\n";
		return;
	}
}


int main()
{
	int w_cnt{ 1 }, g_cnt{ 1 }, c_cnt{ 1 };
	vector<pair<char, char>> f;
	for (int i = 0; i < w_cnt; ++i)
		f.push_back(std::make_pair('l', 'w'));
	for (int i = 0; i < g_cnt; ++i)
		f.push_back(std::make_pair('l', 'g'));
	for (int i = 0; i < c_cnt; ++i)
		f.push_back(std::make_pair('l', 'c'));

	Node* start = new Node(nullptr, f, 'l', w_cnt, g_cnt, c_cnt);

	std::cout << "BFS\n";
	time_t t_start = clock();
	bfs(start);
	std::cout << (clock() - t_start) / CLOCKS_PER_SEC;

	std::cout << "\n============\nDFS\n";
	t_start = clock();
	dfs(start);
	std::cout << (clock() - t_start) / CLOCKS_PER_SEC;

	std::cout << "\n============\nIDS\n";
	t_start = clock();
	ids(start);
	std::cout << (clock() - t_start) / CLOCKS_PER_SEC;

}