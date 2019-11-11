import matplotlib.pyplot as plt

x = [0, 1, 2, 2.1, 2.2, 2.3, 2.4, 2.5, 2.6, 2.7, 2.8, 2.9, 3, 4, 5]
y = [4.96, 4.96, 4.96, 4.96, 4.96, 2.77, 2.45, 2.19, 1.87, 0, 0, 0, 0, 0, 0]

plt.plot(x, y)
plt.grid()
plt.xlabel('Uвхб, В')
plt.ylabel('Uвыхб, В')
plt.title('Амплитудная характеристика ЛЭ И-НЕ')
plt.show()