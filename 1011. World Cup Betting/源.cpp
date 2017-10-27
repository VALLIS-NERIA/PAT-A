#include <iostream>
using namespace std;
static char type[] = {'W','T','L'};
static char bet[3];
static float odd_m[3] = {0,0,0};

int main() {
    float odd[3][3];
    float sum = 1;
    for (int i = 0; i < 3; i++) {
        for (int j = 0; j < 3; j++) {
            cin >> odd[i][j];
            if (odd[i][j] > odd_m[i]) {
                odd_m[i] = odd[i][j];
                bet[i] = type[j];
            }
        }
        cout << bet[i] << ' ';
        sum *= odd_m[i];
    }
    printf("%.2f\n", (sum * 0.65 - 1) * 2);
    //system("pause");
}
