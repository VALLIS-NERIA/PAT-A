#include <iostream>
#include <map>
#include <cstdint>
using namespace std;

int main() {
    int n;
    cin >> n;
    int now = 0;
    int next;
    int time = 0;
    while (n--) {
        cin >> next;
        if (next > now) {
            time += (next - now) * 6 + 5;
        }
        else if (next < now) {
            time += (now - next) * 4 + 5;
        }
        else {
            time += 5;
        }
        now = next;
    }
    cout << time << endl;
}
