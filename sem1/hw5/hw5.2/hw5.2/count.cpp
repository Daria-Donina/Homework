#include <stdio.h>
#include "count.h"
#include "cyclicList.h"

CyclicList *addWarriors(int n)
{
	CyclicList *cyclicList = createCyclicList();
	for (int i = 1; i <= n; ++i)
	{
		add(cyclicList, i);
	}
	return cyclicList;
}

int killing(CyclicList *cyclicList, int m)
{
	auto current = head(cyclicList);
	while (!isOneNode(cyclicList))
	{
		for (int i = 1; i < m; ++i)
		{
			current = next(current);
		}
		auto temp = current;
		current = next(current);
		remove(cyclicList, temp);
	}
	return nodeNumber(current);
}