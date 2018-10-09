#include <vector>
#include <iostream>
#include <unordered_set>
#include <queue>
#include <chrono>
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
	int wolf_cnt, goat_cnt, cabbage_cnt;

	Node(Node* p, const vector<pair<char, char>> & f, char b, int w_cnt = 1, int g_cnt = 1, int c_cnt = 1) : parent{ p }, boat{ b }, field{ f }, wolf_cnt{ w_cnt }, goat_cnt{ g_cnt }, cabbage_cnt{ c_cnt }
	{
		std::sort(field.begin(), field.end());

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
		int left_wolf = 0, left_goat = 0, left_cabbage = 0;
		for (auto it : field)
		{
			if (it.first != 'l') break;
			switch (it.second)
			{
				case 'w': ++left_wolf;
					break;
				case 'g': ++left_goat;
					break;
				case 'c': ++left_cabbage;
					break;
				default:
					break;
			}
		}
		int right_wolf = wolf_cnt - left_wolf;
		int right_goat = goat_cnt - left_goat;
		int right_cabbage = cabbage_cnt - left_cabbage;

		if (boat == 'l')
		{
			if ((right_goat && right_wolf >= right_goat) || (right_cabbage && right_goat >= right_cabbage))
				sb_is_eaten = true;
			else sb_is_eaten = false;
		}
		else
		{
			if ((left_goat && left_wolf >= left_goat) || (left_cabbage && left_goat >= left_cabbage))
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
	if (n1->field != n2->field)
		return false;

	return true;
};

std::list<Node*> all_children(Node* start)
{
	std::list<Node*> res;
	char new_boat = start->boat == 'l' ? 'r' : 'l';
	res.push_back(new Node(start, start->field, new_boat, start->wolf_cnt, start->goat_cnt, start->cabbage_cnt));
	vector<pair<char, char>> new_field(start->field);
	for (int i = 0; i < new_field.size(); ++i)
	{
		if (new_field[i].first != start->boat)
			continue;
		new_field[i].first = new_boat;
		res.push_back(new Node(start, new_field, new_boat, start->wolf_cnt, start->goat_cnt, start->cabbage_cnt));
		new_field[i].first = start->boat;
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
		for (const auto& c : chlds)
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
		std::cout << "There is no answer :(\n";
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
			if (tmp != f)
				delete tmp;
		}
	}
}

std::unordered_set<Node*, decltype(node_hash), decltype(eq)> dfs_used(100, node_hash, eq);
bool found_answ = false;

void dfs_help(Node* f)
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
	auto chlds = all_children(f);
	for (const auto& c : chlds)
	{
		if (!c->sb_is_eaten && dfs_used.find(c) == dfs_used.end())
			dfs_help(c);
		else
			delete c;
	}
}

void dfs(Node* f)
{
	dfs_help(new Node(nullptr, f->field, f->boat, f->wolf_cnt, f->goat_cnt, f->cabbage_cnt));
	dfs_used.clear();
}

bool DLS(Node* f, int depth, int limit)
{
	dfs_used.insert(f);
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
				delete tmp;
			}
			return true;
		}

		auto chlds = all_children(f);
		for (const auto& c : chlds)
		{
			if (!c->sb_is_eaten && dfs_used.find(c) == dfs_used.end())
			{
				if (DLS(c, depth + 1, limit))
					return true;
			}
			else
				delete c;
		}
	}
	return false;
}

void ids(Node* f)
{
	int lim = -1;
	Node* tmp = new Node(nullptr, f->field, f->boat, f->wolf_cnt, f->goat_cnt, f->cabbage_cnt);
	do
	{
		dfs_used.clear();
		++lim;
		if (lim == 1000)
			break;
	}
	while (!DLS(tmp, 0, lim));
	//while (!DLS(tmp, 0, lim))
	//{
	//	++lim;
	//	if (lim == 1000)
	//		break;
	//}
	dfs_used.clear();
	if (lim == 1000)
	{
		std::cout << "There is no answer :(\n";
		return;
	}
}


int main()
{
	int w_cnt{ 10 }, g_cnt{ 20 }, c_cnt{ 200 };
	vector<pair<char, char>> f;
	for (int i = 0; i < w_cnt; ++i)
		f.push_back({ 'l', 'w' });
	for (int i = 0; i < g_cnt; ++i)
		f.push_back({ 'l', 'g' });
	for (int i = 0; i < c_cnt; ++i)
		f.push_back({ 'l', 'c' });

	Node* start = new Node(nullptr, f, 'l', w_cnt, g_cnt, c_cnt);

	std::cout << "BFS\n";
	auto t_start = std::chrono::steady_clock::now();
	bfs(start);
	auto t_end = std::chrono::steady_clock::now();
	std::cout << std::chrono::duration_cast<std::chrono::milliseconds>(t_end - t_start).count() << " milliseconds";

	std::cout << "\n============\nDFS\n";
	t_start = std::chrono::steady_clock::now();
	dfs(start);
	t_end = std::chrono::steady_clock::now();
	std::cout << std::chrono::duration_cast<std::chrono::milliseconds>(t_end - t_start).count() << " milliseconds";

	//std::cout << "\n============\nIDS\n";
	//t_start = std::chrono::steady_clock::now();
	//ids(start);
	//t_end = std::chrono::steady_clock::now();
	//std::cout << std::chrono::duration_cast<std::chrono::milliseconds>(t_end - t_start).count() << " milliseconds";
}