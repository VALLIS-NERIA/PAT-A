#include <iostream>
using namespace std;

int main() {
	while (1) {
		int n;
		cin >> n;
		auto a = new int[n];
		for (int i = 0; i < n; i++) {
			cin >> a[i];
		}
		int maximum = INT32_MIN;
		int max_begin = -1;
		int max_end = -1;
		for (int begin = 0; begin < n; begin++) {
			int sum = 0;
			for (int end = begin; end < n; end++) {
				sum += a[end];
				if (sum > maximum) {
					maximum = sum;
					max_begin = begin;
					max_end = end;
				}
			}
		}
		if (maximum < 0) {
			cout << "0 " << a[0] << " " << a[n-1] << endl;
		}
		else {
			printf("%d %d %d\n", maximum, a[max_begin], a[max_end]);
		}		
	}
}
