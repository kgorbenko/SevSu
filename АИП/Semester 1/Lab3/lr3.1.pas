program lr3;

var
  y, x, truey, error: real;
  i, n: integer;

begin
  write('Введите x: '); read(x);
  write('Введите количество повторов '); read(n);
  
  y := x;
  
  truey := exp(ln(x) / -3);                {Вычисление точного значения функции}
  writeln('Точное значение функции ', truey);
  
  for i:=1 to n do  
  
  begin
    y := (y - x * sqr(sqr(y))) / 3 + y;   
    error := abs(truey - y);               {Определение погрешности вычисления}
    writeln(i);
    writeln('y=', y);
    writeln('Погрешность=', error);
  end;
end.