"""
    Day 6 of 2017 Advent of Code
"""

import numpy
import itertools

bank_configs = []

#def day7_part1():

print("Day 6, Part 1")

testinput = "0,2,7,0"
input = "14	0	15	12	11	11	3	5	1	6	8	4	9	1	8	4"

#memory_bank = [int(x) for x in testinput.split(',') if x]
memory_bank = [int(x) for x in input.split('\t') if x]
steps = 0

print(memory_bank)

while 1:
    steps = steps + 1
    #print("bank_configs at top = ")
    #print(bank_configs)
    maximum = numpy.max(memory_bank)
    maxindex = numpy.argmax(memory_bank)
    #print("maximum = %d" % (maximum))
    #print("maxindex = %d" % (maxindex))

    index = maxindex
    memory_bank[index] = 0
    while maximum > 0:
        nextindex = index + 1
        if nextindex >= len(memory_bank):
            nextindex = 0
        
        #print("nextindex = %d" % (nextindex))
        memory_bank[nextindex] = memory_bank[nextindex] + 1
        maximum = maximum - 1
        #print(memory_bank)
        index = nextindex

    print("\n")
    #print(memory_bank)
    #print(bank_configs)
    if memory_bank not in bank_configs:  # bank_configs doesn't contain configuration
        #print("in memory_bank, bank_configs if")
        #print(memory_bank)
        bank_configs.append(memory_bank[:])
        #print(bank_configs)
        #steps = steps + 1
    else:
        print("Number of steps = %d" % (steps))
        #print(memory_bank)
        print(len(bank_configs))
        break

#day7_part1()
