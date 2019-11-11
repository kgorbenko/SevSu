import matplotlib.pyplot as plt

x = [100, 1000, 10000, 100000]

y1 = [1.44,	1.44, 1.44, 0.780]
y2 = [2.96, 2.96, 2.72,	0.780]
y3 = [5.4, 5.4,	3.68, 0.740]
y4 = [7.2, 7.0,	3.92, 0.740]
y5 = [9.4, 9.4,	4.16, 0.740]

plt.plot(x, y5)
plt.grid()
plt.xscale('log')
plt.xlabel('f, Гц')
plt.ylabel('Uвых, В')
plt.show()