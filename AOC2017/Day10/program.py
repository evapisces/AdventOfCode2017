"""
    Program for Advent of Code Day 10
"""

import numpy
import itertools

print("Day 10, Part 1")

maxIndex = 256
lengths = []

testMaxIndex = 5
testlengths = [3,4,1,5]

mylist = [0,1,2,3,4]

currentIndex = 0
skipsize = 0

print(numpy.array(mylist)[[3,-2]])

for length in testlengths:
    start = currentIndex
    end = length + skipsize

    mylist[start:end] = mylist[start:end][::-1]
    print("mylist[%d:%d] = %s" % (start, end, mylist))
    currentIndex = length + skipsize

    if (length + skipsize >= len(testlengths)):
        currentIndex = 

    skipsize = skipsize + 1
    print("currentindex (end) = %d") % (currentIndex)
    print("skipsize (end) = %d") % (skipsize)