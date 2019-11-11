program lr5;

const
  n = 4;

type
  massive = array [1..n, 1..n] of real;

var
  i, j: integer;
  line: string;
  input, output: text;
  E, F, buff: massive;

function MinimalFromPositive (var mass: massive; size : byte) : real;
var
  min: real;
  i, j: byte;
begin
min:=1.7e38; {максимальное значение для типа real}

for i:=1 to size do
  for j:=1 to size do 
    if (mass[i, j] < min) and (mass[i, j] > 0) then min := mass[i, j];
    
MinimalFromPositive := min;
end;

procedure Transpose(var mass: massive; size : byte);
var
  i, j: byte;
  t : real;
begin
  for i := 1 to size do
    for j := i + 1 to size do begin
      t := mass[i,j];
      mass[i,j] := mass[j,i];
      mass[j,i] := t;
      end;
end;

begin
  {Введение с клавиатуры матрицы F}
  writeln('Введите элементы(16) матрицы F');  
  for i := 1 to n do    
    for j := 1 to n do
      readln(F[i, j]);
  
  assign(input, 'matrix.txt');
  reset(input);
  
  {Поиск стороки, содержащей E; 
  ввод элементов из файла в массив}
  while not eof(input) do
  begin
    readln(input, line);
    if pos('E', line) > 0 then 
    begin
      for i := 1 to n do 
        for j := 1 to n do
          read(input, E[i, j]);
      {выход из цикла поиска подстроки 
      в случае заполнения массива}
      break;            
    end;
  end;
  
  close(input);
  
  assign(output, 'result.txt');
  rewrite(output);
  
  writeln(output, 'Минимальный положительный элемент E: ', MinimalFromPositive(E, n));
  writeln(output, 'Минимальный положительный элемент F: ', MinimalFromPositive(F, n));
  
  writeln(output, 'Транспонированная E: ');
  Transpose(E, n);
  
  for i:=1 to n do
    begin
    for j:=1 to n do 
      write(output, E[i, j]:9);
    writeln(output);  
    end;
  
  writeln(output, 'Транспонированная F: ');
  Transpose(F, n);
  
  for i:=1 to n do
    begin
    for j:=1 to n do
      write(output, F[i, j]:9);
    writeln(output);
    end;
      
  close(output);
  
end.