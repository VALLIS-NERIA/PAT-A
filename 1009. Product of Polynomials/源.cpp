#include <iostream>
#include <map>
#include <vector>
#include <algorithm>
using namespace std;

int main() {
    map<int, float> exp1, exp2, exp3;
    int k;
    cin >> k;
    while (k--) {
        int ex;
        float co;
        cin >> ex >> co;
        exp1[ex] = co;
    }
    cin >> k;
    while (k--) {
        int ex;
        float co;
        cin >> ex >> co;
        exp2[ex] = co;
    }

    for (auto pair1:exp1) {
        for (auto pair2:exp2) {
            int ex = pair1.first + pair2.first;
            float co = pair1.second * pair2.second;
            if (!exp3.count(ex)) {
                exp3[ex] = 0.0;
            }
            exp3[ex] += co;
            if (exp3[ex] == 0.0) {
                exp3.erase(ex);
            }
        }
    }
    vector<pair<int, float>> v(exp3.begin(), exp3.end());
    sort(v.begin(), v.end(), [](pair<int, float>& left, pair<int, float>& right) { return left.first > right.first; });
    cout << v.size() << " ";
    for (auto iter = v.begin(); iter != v.end(); ++iter) {
        //cout << iter->first << " " << iter->second;
        printf("%d %.1f", iter->first, iter->second);
        if (iter != v.end() - 1) {
            cout << " ";
        }
    }
    cout << endl;
}
