#pragma once
#include <stdlib.h>


class Singleton
{
private:
	static Singleton* m_instance;

protected:
	Singleton(void);

public:
	static Singleton* Instance(void);
	virtual ~Singleton(void);
};