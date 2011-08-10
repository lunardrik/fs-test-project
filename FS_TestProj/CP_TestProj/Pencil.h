#pragma once
#include <iostream>
using namespace std;

class Pencil
{
private:
	int m_Radius;
	char* m_Producer;
public:

	Pencil(void);

	// Copy constructor
	//Pencil(const Pencil & clonedObject);

	// Print to output the type of the current pencil
	void ShowType(void);

	// Set current Pencil radius
	void SetRadius(int);
	// Set current Pencil Producer
	void SetProducer(char*);

	// Get current Pencil radius
	int GetRadius(void) const;
	// Get current Pencil Producer
	char* GetProducer(void) const;

	virtual ~Pencil(void);
};

