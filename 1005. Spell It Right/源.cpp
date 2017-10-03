#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <map>
using namespace std;


vector<int> convert(int x) {
	vector<int> list;
	if (x == 0)list.push_back(0);
	while (x) {
		int a = x % 10;
		x = x / 10;
		list.push_back(a);
	}
	//reverse(list.begin(), list.end());
	return list;
}

map<int, string> english = {{0,"zero"},{1,"one"},{2,"two"},{3,"three"},{4,"four"},{5,"five"},{6,"six"},{7,"seven"},{8,"eight"},{9,"nine"}};

int main() {
	string s;
	cin >> s;
	int sum = 0;
	for (char c : s) {
		sum += c - '0';
	}
	auto list = convert(sum);
	for (auto iter = list.rbegin(); iter != list.rend(); ++iter) {
		if (iter != list.rend() - 1) {
			cout << english[*iter] << " ";
		}
		else {
			cout << english[*iter] << endl;
		}
	}
}
