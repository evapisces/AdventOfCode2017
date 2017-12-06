import codecs
import numpy

BOM = codecs.BOM_UTF8.decode('utf8')

offsets = []

print "Day 5, Part 1"

# Opening the file for reading
with codecs.open("input.txt", encoding='utf-8') as file:
    intermed = []

    # Looping through each line of the file
    for line in file:
        line = line.lstrip(BOM)
        intermed.append(line.replace('\n', ''))

# Convert array of strings to array of ints
offsets = map(int, intermed)
print offsets
print len(offsets)
index = 0
ctr = 0
while index < len(offsets):
    ctr = ctr + 1
    print "index = %d, offsets[index] = %d" % (index, offsets[index])
    if (offsets[index] == 0):
        offsets[index] = offsets[index] + 1
    else:
        temp = index
        index = index + offsets[index]
        offsets[temp] = offsets[temp] + 1

print offsets
print "ctr = %d" % (ctr)


offsets = []

print "Day 5, Part 2"

# Opening the file for reading
with codecs.open("input.txt", encoding='utf-8') as file:
    intermed = []

    # Looping through each line of the file
    for line in file:
        line = line.lstrip(BOM)
        intermed.append(line.replace('\n', ''))

# Convert array of strings to array of ints
offsets = map(int, intermed)
print offsets
print len(offsets)
index = 0
ctr = 0
while index < len(offsets):
    ctr = ctr + 1
    print "index = %d, offsets[index] = %d" % (index, offsets[index])
    if (offsets[index] == 0):
        offsets[index] = offsets[index] + 1
    elif (offsets[index] >=3):
        temp = index
        index = index + offsets[index]
        offsets[temp] = offsets[temp] - 1
    else:
        temp = index
        index = index + offsets[index]
        offsets[temp] = offsets[temp] + 1

print offsets
print "ctr = %d" % (ctr)
