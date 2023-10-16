#include <stdio.h>


//void IkiSayiyiBolme(double a, double b);
int main() {

    double sayi1, sayi2;

    printf("Birinci sayiyi giriniz: ");
    scanf("%lf", &sayi1);
    printf("Ikinci sayiyi giriniz: ");
    scanf("%lf", &sayi2);


    IkiSayiyiBolme(sayi1, sayi2);
    return 0 ;

}
void IkiSayiyiBolme(double a, double b) {

double bolum = a / b;

printf("Sayinin bolumu = %lf", bolum);

}
