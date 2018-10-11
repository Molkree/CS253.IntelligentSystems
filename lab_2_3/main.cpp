#include <iostream>
#include <vector>
#include <string>

const int WOLF_W = 2;
const int SHEEP_W = 1;
const int NOTHING = 0;
using namespace std;

vector<int> dx{ 1, 1, -1, -1 };
vector<int> dy{ 1, -1, -1, 1 };

class Node
{
public:

	vector<pair<uint_fast8_t, uint_fast8_t>> wolves;
	pair<uint_fast8_t, uint_fast8_t> sheep;
	
	//sheep - 1, wolfs - 2, nothing - 0
	int terminal()
	{
		if (sheep.second == 7)
			return 1;

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
		if (dead) return 2;
		return 0;
	}

	Node(const pair<uint_fast8_t, uint_fast8_t>& w1, const pair<uint_fast8_t, uint_fast8_t>& w2, const pair<uint_fast8_t, uint_fast8_t>& w3, 
		const pair<uint_fast8_t, uint_fast8_t>& w4, const pair<uint_fast8_t, uint_fast8_t>& sheep)
	{
		wolves.push_back(w1);
		wolves.push_back(w2);
		wolves.push_back(w3);
		wolves.push_back(w4);
		this->sheep = sheep;
	}
	Node(const Node& n)
	{
		wolves.assign(n.wolves.begin(), n.wolves.end());
		this->sheep = n.sheep;
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
private:

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
		if (i == numb) continue;
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

int main()
{
	Node* start = new Node(make_pair(0, 7), make_pair(2, 7), make_pair(4, 7), make_pair(6, 7), make_pair(1, 0));

	cout << "Choose a side: a sheep(1) or wolves(2). Enter the number: ";
	int player_n;
	cin >> player_n;
	cout << "\n";
	cout << "Lower left square has coordinates 1 1\n";
	cout << start->print() << endl;
	//при вводе везде индексация с единицы, в программе везде(!) с нуля
	--player_n;
	//таки первым всегда ходит заяц? если игрок выбрал зайца, то первым ходит игрок, иначе первым ходит система
	//0 ход игрока, 1 ход системы
	int turn = player_n == 0? 0 : 1;
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