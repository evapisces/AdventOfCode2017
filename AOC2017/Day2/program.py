import io
import codecs
import numpy

BOM = codecs.BOM_UTF8.decode('utf8')
sum = 0
print "Day 2, Part 1"

# Opening the file for reading
with codecs.open("input.txt", encoding='utf-8') as file:
    # Looping through each line of the file
    for line in file:
        line = line.lstrip(BOM)

        # Convert string of ints to array of ints
        line_ints = map(int, line.split('\t'))

        # Get max value in list
        max = numpy.max(line_ints)

        # Get min value in list
        min = numpy.min(line_ints)
        diff = max - min
        #print "%d - %d = %d" % (max, min, diff)
        sum = sum + diff

print "Sum = %d" % (sum)


print "Day 2, Part 2"
sum = 0

with codecs.open("input.txt", encoding='utf-8') as file:
    for line in file:
        line = line.lstrip(BOM)

        ints = map(int, line.split('\t'))

        for i, num in enumerate(ints):
            item = ints[i]
            #print item
            for num in ints:
                if item % num == 0 and item != num:
                    #print "item = %d, num = %d" % (item, num)
                    if item > num:
                        sum = sum + (item/num)
                    else :
                        sum = sum + (num/item)
                    break
print "Sum = %d" % (sum)
