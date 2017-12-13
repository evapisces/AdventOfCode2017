import codecs
import numpy

BOM = codecs.BOM_UTF8.decode('utf8')

layers = []
firewall = []


print "Day 5, Part 1"

# Opening the file for reading
with codecs.open("testinput.txt", encoding='utf-8') as file:
    
    # Looping through each line of the file
    for line in file:
        line = line.lstrip(BOM)
        test = line.replace(' ', '').replace('\n', '').split(':')
        layers.append(map(int, test))
        s1 = [int(test[0])]
        s2 = []
        for i in range(int(test[1])):
            s2.append('[]')
        s1.append(s2)
        firewall.append(s1)
        

    print(layers)
    print(firewall)
    firewall = numpy.array(firewall)
    print(firewall[:,0])