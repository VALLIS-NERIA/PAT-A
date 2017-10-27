#include <iostream>
#include <vector>
#include <string>
using namespace std;

inline int to_num(char c) {
    if (c >= '0' && c <= '9') {
        return c - '0';
    }
    if (c >= 'a' && c <= 'z') {
        return c - 'a' + 10;
    }
    throw exception();
}

// radix is int64
int64_t to_int(string n, int64_t radix) {
    int64_t x = 0;
    for (char c:n) {
        int a = to_num(c);
        if (a >= radix) {
            return 0;
        }
        x = x * radix;
        if (x < 0)return 0x7fffffffffffffffLL;
        x += a;
        if (x < 0)return 0x7fffffffffffffffLL;
    }
    return x;
}

int main() {
    string s1, s2;
    int tag, radix0;
    cin >> s1 >> s2 >> tag >> radix0;
    int64_t n1, n2;
    if (tag == 2) {
        swap(s1, s2);
    }
    n1 = to_int(s1, radix0);
    // radix的上限和数一样大，所以ijk都是int64
    int64_t i = 0;
    int64_t j = n1 + 1;
    // 二分查找，不然超时
    while (i <= j) {
        int64_t k = (i + j) / 2;
        n2 = to_int(s2, k);
        if (n1 == n2) {
            cout << k << endl;
            return 0;
        }
        if (n2 > n1) {
            j = k - 1;
        }
        if (n2 < n1) {
            i = k + 1;
        }
    }

end:
    cout << "Impossible" << endl;
}
