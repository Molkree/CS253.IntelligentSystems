#include <iostream>
#include <vector>
#include <string>
#include <queue>
#include <map>
#include <algorithm>

const int WOLF = 0;
const int SHEEP = 1;
const int NOTHING = 2;
using namespace std;

typedef pair<uint_fast8_t, uint_fast8_t> coord;

vector<int> dx{ -1, 1, 1, -1 };
vector<int> dy{ -1, -1, 1, 1 };

class Node
{
public:

	vector<coord> wolves;
	coord sheep;
	bool isWolf;
	
	//sheep - 1, wolfs - 0, nothing - 2
	int terminal()
	{
		if (sheep.second == 7)
			return SHEEP;

		bool dead = true;
		for (int i = 0; i < 4; ++i)
		{
			int pos_x = sheep.first + dx[i];
			int pos_y = sheep.second + dy[i];
			if (pos_x < 0 || pos_x > 7 || pos_y < 0 || pos_y > 7)
				continue;
			for (int j = 0; j<4; ++j)
				if (wolves[j].first != pos_x || wolves[j].second != pos_y)
				{
					dead = false;
					break;
				}
			if (!dead) break;
		}
		if (dead) return WOLF;
		return NOTHING;
	}

	Node(const coord& w1, const coord& w2, const coord& w3,
		const coord& w4, const coord& sheep, int player = 1)
	{
		wolves.push_back(w1);
		wolves.push_back(w2);
		wolves.push_back(w3);
		wolves.push_back(w4);
		this->sheep = sheep;
		isWolf = (player == 0);
	}
	Node(const Node& n)
	{
		wolves.assign(n.wolves.begin(), n.wolves.end());
		this->sheep = n.sheep;
		this->isWolf = n.isWolf;
	}

	string print()
	{
		string res = "";
		for (int i = 0; i < 7; ++i)
			res += "_|_|_|_|_|_|_|_\n";
		res += " | | | | | | | \n";
		//заполняем черными квадратами (звездочками)
		for (int i = 0; i < 8; ++i)
			for (int j = 0; j < 8; ++j)
				if (i % 2 == 0)
				{
					if (j % 2 == 0)
						res[16 * i + j * 2] = '*';
				}
				else
					if (j % 2 == 1)
						res[16 * i + j * 2] = '*';
		
		//заполняем животными
		for (int i = 0; i < 4; ++i)
			res[16 * (7 - wolves[i].second) + wolves[i].first * 2] = 1+ i + '0';
		res[16 * (7 - sheep.second) + sheep.first * 2] = 's';
		return res;
	}
//private:

	// number of steps to finish for sheep
	// if finish is unreachable return 254
	int heuristic()
	{
		map<coord, int> dist;
		queue<coord> q;
		vector<coord> used;

		q.push(sheep);
		dist[sheep] = 0;

		while (!q.empty())
		{
			coord pos = q.front();

			used.push_back(pos);
			q.pop();

			if (pos.second == 7)
				return dist[pos];


			for (int i = 0; i < 4; ++i)
			{
				int pos_x = pos.first + dx[i];
				int pos_y = pos.second + dy[i];

				// if pos is out of range - we can't go there - continue
				if (pos_x < 0 || pos_x > 7 || pos_y < 0 || pos_y > 7)
					continue;

				// if wolf is on pos - we can't go there - continue
				bool wolf = false;
				for (int j = 0; j < 4; ++j)
					if (wolves[j].first == pos_x && wolves[j].second == pos_y)
					{
						wolf = true;
						break;
					}
				if (wolf)
					continue;

				coord new_pos = make_pair(pos_x, pos_y);
				if (find(used.begin(), used.end(), new_pos) == used.end())
				{
					dist[new_pos] = dist[pos] + 1;
					q.push(new_pos);
				}
				else
					if (dist[new_pos] > dist[pos] + 1)
						dist[pos] = dist[pos] + 1;
			}
		}
		return 254;
	}

	// vector of wolves' possible positions
	vector<vector<coord>> wolf_next_moves()
	{
		vector<vector<coord>> next_moves;

		for (int j = 0; j < wolves.size(); ++j)
		{
			// i < 2 because wolves can't go back
			for (int i = 0; i < 2; ++i)
			{
				int pos_x = wolves[j].first + dx[i];
				int pos_y = wolves[j].second + dy[i];

				if (pos_x < 0 || pos_x > 7 || pos_y < 0 || pos_y > 7)
					continue;

				if (pos_x == sheep.first && pos_y == sheep.second)
					continue;

				vector<coord> move(wolves);
				move[j] = make_pair(pos_x, pos_y);
				next_moves.push_back(move);
			}
		}
		return next_moves;
	}

	// vector of sheep's possiple moves
	vector<coord> sheep_next_moves()
	{
		vector<coord> next_moves;
		for (int i = 0; i < 4; ++i)
		{
			int pos_x = sheep.first + dx[i];
			int pos_y = sheep.second + dy[i];
			if (pos_x < 0 || pos_x > 7 || pos_y < 0 || pos_y > 7)
				continue;
			bool wolf = false;
			for (int j = 0; j < 4; ++j)
				if (wolves[j].first == pos_x && wolves[j].second == pos_y)
				{
					wolf = true;
					break;
				}
			if (wolf)
				continue;

			next_moves.push_back(make_pair(pos_x, pos_y));

		}
		return next_moves;
	}

};

bool check_woolf_coord(int x, int y, int numb, Node* n)
{
	if (x < 0 || y < 0 || x>7 || y>7)
		return false;
	if (numb > 3 || numb < 0)
		return false;

	//еще проверить, что клетка не занята
	if (x == n->sheep.first && y == n->sheep.second)
		return false;
	for (int i = 0; i < 4; ++i)
	{
	//	if (i == numb) continue; // ведь если введены текущие координаты волка, мы не можем остаться на месте
		if (x == n->wolves[i].first && y == n->wolves[i].second)
			return false;
	}

	//волк ходит только вниз
	if (y != n->wolves[numb].second - 1)
		return false;
	if (x == n->wolves[numb].first - 1 || x == n->wolves[numb].first + 1)
		return true;
	return false;
}

bool check_sheep_coord(int x, int y, Node* n)
{
	if (x < 0 || y < 0 || x>7 || y>7)
		return false;
	//занята
	for (int i = 0; i < 4; ++i)
		if (x == n->wolves[i].first && y == n->wolves[i].second)
			return false;
	//заяц ходит и вниз, и вверх
	for (int i = 0; i < 4; ++i)
		if (x == n->sheep.first + dx[i] && y == n->sheep.second + dy[i])
			return true;
	return false;
}

// returns f(Vi)
int minMax(Node* curr, int depth, int max_depth)
{
/*	if (depth >= max_depth)
		return curr->heuristic();

	int best_move = -1;
	//	bool isWolf = (curr->player == WOLF);
	int min_max = (curr->isSheep) ? INT32_MAX : INT32_MIN;

	// it's sheep's turn
	if (curr->isSheep)
	{
		for (auto move : curr->sheep_next_moves())
		{

		}

	}
	else // it's wolf's turn
	{

	}
*/
	return 0;
}


void start_game()
{
	cout << "Choose a side: a sheep(1) or wolves(2). Enter the number: ";
	int player_n;
	cin >> player_n;

	while (!(player_n == 1 || player_n == 2))
	{
		cout << "Please, enter \"1\" or \"2\", and nothing else.\n";
		cin >> player_n;
	}
	
	//при вводе везде индексация с единицы, в программе везде(!) с нуля
	--player_n; // now 0 is sheep, 1 is wolves 

	Node* start = new Node(make_pair(0, 7), make_pair(2, 7), make_pair(4, 7), make_pair(6, 7), make_pair(1, 0), player_n);


	cout << "\n";
	cout << "Lower left square has coordinates 1 1\n";
	cout << start->print() << endl;

	
	// первым всегда ходит заяц, если игрок выбрал зайца, то первым ходит игрок, иначе первым ходит система
	// 0 - ход игрока, 1 - ход системы
	int turn = player_n == 0 ? 0 : 1;
	//while (true)
	//{
	if (turn == 0) //ход игрока
	{
		cout << "Your turn:\n";
		if (player_n == 0) //играет зайцем
		{
			int x = -1, y = -1;
			while (!check_sheep_coord(x, y, start))
			{
				cout << "Enter coordinates: ";
				cin >> x >> y; cout << "\n";
				--x; --y;
			}

			//потом изменю переприсваивание
			start->sheep.first = x;
			start->sheep.second = y;
		}
		else
		{
			int numb = -1, x = -1, y = -1;
			while (!check_woolf_coord(x, y, numb, start))
			{
				cout << "Enter wolve's number(1/2/3/4) and coordinates: ";
				cin >> numb >> x >> y; cout << "\n";
				--numb; --x; --y;
			}
			start->wolves[numb].first = x;
			start->wolves[numb].second = y;
		}
	}
	else //ход системы
	{
		// а надо отличать, кем ходит система?
		cout << "Waiting for system..\n";
		//TODO: turns
	}
	//и где переопределится само поле?
	cout << start->print() << endl;
	// TODO if terminal... break
	//}

}

int main()
{
	Node* start = new Node(make_pair(0, 7), make_pair(2, 7), make_pair(4, 7), make_pair(6, 7), make_pair(1, 0), SHEEP); // h = 254


	//	Node* start = new Node(make_pair(0, 5), make_pair(3, 4), make_pair(5, 6), make_pair(7, 6), make_pair(5, 4)); // h = 3
	//	Node* start = new Node(make_pair(0, 7), make_pair(1, 6), make_pair(4, 7), make_pair(6, 7), make_pair(5, 2)); // h = 5

	cout << start->heuristic() << endl;
	cout << start->print() << endl;

}