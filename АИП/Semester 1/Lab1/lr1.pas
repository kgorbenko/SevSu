program strangeFormula;
  var x: integer;
      a,b,c,z,m,k: real;
      
begin

read(x, z);

k:=exp(pi*x)*cos(0.01*z);

a:=sqrt(Ln(k)+1000);
b:=sqrt(1000-Ln(k));
c:=sqr(x)+18*x-40;

m:=(a-b)/c;

writeln(m);
  
end.  