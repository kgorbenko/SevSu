program rgz;

const
  n = 7;

var
  i, j, k: byte; 
  swap, counter: integer;
  objects: array[1..7] of integer;

begin
  writeln('Введите элементы массива один за другим');
  for j := 1 to n do readln(objects[j]);
  
  for k := 1 to n - 1 do
  begin
    writeln('Этап №', k);
    counter := 0;
    for i := n downto k + 1 do  
    begin
      if objects[i] > objects[i - 1] then
      begin
        swap := objects[i - 1];
        objects[i - 1] := objects[i];
        objects[i] := swap;
        counter := counter + 1;
      end;
      
      for j := 1 to n do
        write(objects[j]:3);
      writeln;
    end;
    if counter = 0 then 
    begin
      writeln('Досрочное завершение алгоритма сортировки');
      writeln('Отсортированная последовательность:');
      for j := 1 to n do write(objects[j]:4);
      readln;
      exit;
    end;
  end;
end.


