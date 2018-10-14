#include <iostream>
#include <vector>
#include <string>
#include <queue>
#include <map>
#include <algorithm>

const int WOLF = 1;
const int SHEEP = 0;
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
	
	//sheep - 0, wolves - 1, nothing - 2
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

	Node(const vector<coord> wolves, const coord& sheep, int player = 1) : wolves(wolves), sheep(sheep)
	{
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

Node* next_move = nullptr;

// returns f(Vi)
int runMinMax(Node* curr, int depth, int max_depth)
{
	int test = -1;

	if (depth >= max_depth)
		return curr->heuristic();

//	int best_move = -1;
	Node* best_move = nullptr;
	int min_max = (curr->isWolf) ? INT32_MIN : INT32_MAX;

	// it's wolf's turn
	if (curr->isWolf)
		for (auto new_wolves : curr->wolf_next_moves())
		{
			// next turn is sheep
			Node * next = new Node(new_wolves, curr->sheep, SHEEP);
			test = runMinMax(next, depth + 1, max_depth);

			if (test > min_max)
			{
				min_max = test;
				best_move = next;
			}
			else
				delete next; // наверное, надо удалять
		}
	else // it's sheep's turn
		for (auto new_sheep : curr->sheep_next_moves())
		{
			// next turn is wolf
			Node* next = new Node(curr->wolves, new_sheep, WOLF);
			test = runMinMax(next, depth + 1, max_depth);

			if (test <= min_max)
			{
				min_max = test;
				best_move = next;
			}
			else
				delete next; // наверное, надо удалять
		}

	if (best_move == nullptr)
		return curr->heuristic();

	if (depth == 0 && best_move != nullptr)
	{
		next_move = best_move;
	}

	return min_max;
}


void start_game()
{
	const int max_depth = 10;

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

	Node* field = new Node(make_pair(0, 7), make_pair(2, 7), make_pair(4, 7), make_pair(6, 7), make_pair(1, 0), player_n);


	cout << "\n";
	cout << "Lower left square has coordinates 1 1\n";
	cout << field->print() << endl;

	
	// первым всегда ходит заяц, если игрок выбрал зайца, то первым ходит игрок, иначе первым ходит система
	// 0 - ход игрока, 1 - ход системы
	int turn = player_n == 0 ? 0 : 1;
	while (true)
	{
		if (turn == 0) //ход игрока
		{
			cout << "Your turn:\n";
			if (player_n == 0) //играет зайцем
			{
				int x = -1, y = -1;
				while (!check_sheep_coord(x, y, field))
				{
					cout << "Enter coordinates: ";
					cin >> x >> y; cout << "\n";
					--x; --y;
				}

				//потом изменю переприсваивание
				field->sheep.first = x;
				field->sheep.second = y;
			}
			else
			{
				int numb = -1, x = -1, y = -1;
				while (!check_woolf_coord(x, y, numb, field))
				{
					cout << "Enter wolve's number(1/2/3/4) and coordinates: ";
					cin >> numb >> x >> y; cout << "\n";
					--numb; --x; --y;
				}
				field->wolves[numb].first = x;
				field->wolves[numb].second = y;
			}
			turn = 1;
		}
		else //ход системы
		{
			// а надо отличать, кем ходит система?
			cout << "Waiting for system..\n";
			runMinMax(field, 0, max_depth);
			delete field;
			field = next_move;
			turn = 0;
			//TODO: turns
		}
		//и где переопределится само поле?
		cout << field->print() << endl;
		int t = field->terminal();
		if (t != NOTHING)
		{
			if (t == player_n)
				cout << "Congratulations! You won!\n";
			else
				cout << "Sorry, you lost :(\n";
			break;
		}
		// TODO if terminal... break
	}

}

int main()
{
	Node* start = new Node(make_pair(0, 7), make_pair(2, 7), make_pair(4, 7), make_pair(6, 7), make_pair(1, 0), SHEEP); // h = 254


	//	Node* start = new Node(make_pair(0, 5), make_pair(3, 4), make_pair(5, 6), make_pair(7, 6), make_pair(5, 4)); // h = 3
	//	Node* start = new Node(make_pair(0, 7), make_pair(1, 6), make_pair(4, 7), make_pair(6, 7), make_pair(5, 2)); // h = 5

	cout << start->heuristic() << endl;
	cout << start->print() << endl;
	


//	start_game();


}