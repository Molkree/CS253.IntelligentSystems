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

	string print()
	{
		string res = "";
		for (int i = 0; i < 7; ++i)
			res += "_|_|_|_|_|_|_|_\n";
		res += " | | | | | | | \n";
		return res;
	}
private:

};

int main()
{
	Node* start = new Node(make_pair(0, 7), make_pair(2, 7), make_pair(4, 7), make_pair(6, 7), make_pair(1, 0));

	cout << start->print() << endl;

}