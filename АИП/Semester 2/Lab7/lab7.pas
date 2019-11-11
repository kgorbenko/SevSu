uses crt;
type
  books = record
    surname: string[15];
    bookName: string[15];
    year: integer;
    genre: string[15];
  end;
  
  pBooks = ^books;
  
  tBooks = array[1..NMAX] of pBooks;

var
  Lib : tBooks;
  userOption: integer;

procedure CreateFile;
var
  f: file of books;
  b: pBooks;
  fileName: string;
  stringBuffer: string;
begin
  ClrScr;
  writeln('Enter file name');
  readln(fileName);
  assign(f, fileName);
  rewrite(f);
  repeat
    new(b);
    with b^ do
    begin
    writeln('Enter author surname');
    readln(surname);
    writeln('Enter book name');
    readln(bookName);
    writeln('Enter publication year');
    readln(year);
    writeln('Enter book genre');
    readln(genre);
    write(f, b^);
    end;
    dispose(b);
    writeln('Would you like to add one mode record? Y/N');
    readln(stringBuffer);
  until (pos('N', stringBuffer) > 0) or (pos('n', stringBuffer) > 0);
  close(f);
end;

procedure ViewFile;
var
  f: file of books;
  b: pBooks;
  fileName: string;
begin
  clrscr;
  writeln('Enter file name');
  readln(fileName);
  assign(f, fileName);
  reset(f);
  writeln('surname':17, 'bookName':17, 'year':6, 'genre':17);
  while not Eof(f) do 
  begin
    new(b);
    read(f, b^);
    with b^ do 
    begin
      writeln(surname:17, bookName:17, year:6, genre: 17);
    end;
    dispose(b);
  end;
  close(f);
  readln;
end;

procedure ViewCurrentYear;
var
  f: file of books;
  b: pBooks;
  fileName: string;
  currentYear: integer;
begin
  clrscr;
  writeln('Enter file name');
  readln(fileName);
  writeln('Enter year to search');
  readln(currentYear);
  assign(f, fileName);
  reset(f);
  writeln('surname':17, 'bookName':17, 'year':6, 'genre':17);
  new(b);
  while not eof(f) do 
  begin
    read(f, b^);
    if (b^.year = currentYear) then
    begin
      with b^ do writeln(surname:17, bookName:17, year:6, genre: 17);
    end;
  end;
  dispose(b);
  close(f);
  readln;
end;

begin
  repeat
    clrscr; 
    writeln('1 - Create file');
    writeln('2 - View file');
    writeln('3 - View current year');
    writeln('4 - Exit');
    readln(userOption);
    case userOption of 
      1: CreateFile();
      2: ViewFile();
      3: ViewCurrentYear();
    end;
  until userOption = 4;
end.