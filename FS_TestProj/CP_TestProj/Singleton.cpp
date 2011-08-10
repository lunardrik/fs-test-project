#include "Singleton.h"

Singleton* Singleton::m_instance = NULL;

Singleton::Singleton(void)
{
	m_instance = NULL;
}

Singleton* Singleton::Instance(void)
{
	if (m_instance == NULL)
		m_instance = new Singleton();

	return m_instance;
}

Singleton::~Singleton(void)
{
}
