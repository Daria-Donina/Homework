#include "priorityQueue.h"
#include <iostream>

using namespace std;

int main()
{
	auto queue = createQueue();

	enqueue(queue, 3, "a");
	enqueue(queue, 7, "b");
	enqueue(queue, 6, "c");
	enqueue(queue, 2, "d");

	while (!isEmpty(queue))
	{
		cout << dequeue(queue) << endl;
	}

	deleteQueue(queue);
	return 0;
}