#include "Pencil.h"


Pencil::Pencil(void)
{
	m_Radius = 3;
	m_Producer = "Pentel";
}

//Pencil::Pencil(const Pencil & clonedObject)
//{
//	m_Radius = clonedObject.GetRadius();
//	m_Producer = clonedObject.GetProducer();
//}

void Pencil::ShowType(void)
{
	cout << "Pencil radius: " << GetRadius() << " - Producer: " << GetProducer() << endl;
}

void Pencil::SetRadius(int r)
{
	m_Radius = r;
}

void Pencil::SetProducer(char* p)
{
	m_Producer = p;
}

int Pencil::GetRadius(void) const
{
	return m_Radius;
}

char* Pencil::GetProducer(void) const
{
	return m_Producer;
}

Pencil::~Pencil(void)
{
	delete m_Producer;
}