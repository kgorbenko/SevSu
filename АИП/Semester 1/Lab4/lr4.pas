program lr4;
{Горбенко Кирилл, ИВТ/б-12о}
const
  n = 8;

type
  massive = array[1..n] of real;

var
  b: integer;
  i: byte;
  mass: massive;
  sum: real;

procedure elements_satisfying(a: integer; size: byte; const massive_given: massive);
var
  i: byte;
begin
  writeln('Результат работы процедуры: ');
  for i := 1 to size do 
    if sqrt(abs(massive_given[i])) < a then writeln(massive_given[i]);
end;

function sum_of_negative(size : byte; const massive_given: massive): real;
var
  i: byte;
  sum: real;
begin
  for i := 1 to size do 
    if massive_given[i] < 0 then sum := sum + massive_given[i];
  sum_of_negative := sum;
end;

begin
  writeln('Введите параметр для использования в процедуре'); readln(b);
  writeln('Вводите по очереди элементы массива');
  
  for i := 1 to n do 
    read(mass[i]);
  
  sum := sum_of_negative(n, mass);
  writeln('Результат работы функции: ', sum);
  
  elements_satisfying(b ,n , mass);
  
end.