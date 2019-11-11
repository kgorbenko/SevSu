import numpy as np
import matplotlib.pyplot as plt
import random

def generate_point(xstart, xend, ystart, yend):
    x = random.uniform(xstart, xend)
    y = random.uniform(ystart, yend)
    return x, y

def integrate(xstart, xend, ystart, yend, function, points_number):
    points_within = []
    points_beyond = []
    within        = 0
    for i in range(points_number):
        x, y = generate_point(xstart, xend, ystart, yend)
        if (y <= function(x) and y > 0):
            points_within.append((x, y))
            within += 1
        elif (y >= function(x) and y < 0):
            points_within.append((x, y))
            within -= 1
        else:
            points_beyond.append((x, y))
    integral = (xend - xstart) * (yend - ystart) * within / points_number 

    return  integral, points_within, points_beyond
        
print('Enter interval start:')
start = float(input())

print('Enter interval end:')
end = float(input())

print('Enter number of points:')
points_number = int(input())

x        = np.linspace(start, end, 100000)
function = np.cos(x)
max      = max(function)
if min(function) >= 0:
    min = 0
else:
    min = min(function)

integral, points_below, points_above = integrate(start, end, min, max, np.cos, points_number)
print('integral value: ', integral)

belowx, belowy = zip(*points_below)
abovex, abovey = zip(*points_above)
plt.scatter(belowx, belowy, color='red')
plt.scatter(abovex, abovey, color='blue')
plt.plot(x, function)
plt.grid()
plt.show()