import codecs
import numpy

BOM = codecs.BOM_UTF8.decode('utf8')

offsets = []

print "Day 11, Part 1"

# Opening the file for reading
with codecs.open("testinput.txt", encoding='utf-8') as file:

    # Looping through each line of the file
    for line in file:
        line = line.lstrip(BOM)
        intermed.append(line.replace('\n', ''))