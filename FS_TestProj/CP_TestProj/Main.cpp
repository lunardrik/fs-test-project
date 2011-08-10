#include <iostream>
#include <math.h>
#include "Pencil.h"
#include "Singleton.h"
using namespace std;

void main()
{
	Singleton* s1 = Singleton::Instance();
	Singleton* s2 = Singleton::Instance();
	
	
	if (s1 == s2)
		cout << "The same";
}