#include <Windows.h>
#include <iostream>

extern "C" __declspec(dllexport) int Plus(int a, int b)
{
	return a + b;
}

extern "C" __declspec(dllexport) int Minus(int a, int b)
{
	return a - b;
}
extern "C" __declspec(dllexport) int Multiplication(int a, int b)
{
	return a * b;
}
extern "C" __declspec(dllexport) int Division(int a, int b)
{
	if (b == 0) {
		std::cout << "ERROR!" << std::endl;
		return 0;
	}
	return a / b;
}