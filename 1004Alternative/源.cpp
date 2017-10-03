#include <iostream>
#include <vector>
using namespace std;

class node;
int max_level;
int stats[101];
node* nodes[101];

class node {
public:
	vector<node*> children;

	void dfs(int level) {
		if (level > max_level) {
			max_level = level;
		}
		if (this->children.empty()) {
			stats[level]++;
		}
		else {
			for (auto child:children) {
				child->dfs(level + 1);
			}
		}
	}
};

int main() {
	int n, m;
	cin >> n >> m;
	for (int i = 0; i < 101; i++) {
		nodes[i] = new node();
	}
	while (m--) {
		int id, k;
		cin >> id >> k;
		auto node = nodes[id];
		while (k--) {
			int child_id;
			cin >> child_id;
			node->children.push_back(nodes[child_id]);
		}
	}
	nodes[1]->dfs(0);
	for(int i=0;i<max_level;i++) {
		cout << stats[i] << " ";
	}
	cout << stats[max_level] << endl;
}
