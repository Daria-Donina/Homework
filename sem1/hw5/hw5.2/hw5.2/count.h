#pragma once

struct Node;

struct CyclicList
{
	Node *head = nullptr;
};

struct Node
{
	int number = 0;
	Node *next = { nullptr };
};

CyclicList *createCyclicList();

void addWarriors(CyclicList *cyclicList, int n);

bool isOnlyOneLeft(CyclicList *cyclicList);

int killing(CyclicList *cyclicList, int m);