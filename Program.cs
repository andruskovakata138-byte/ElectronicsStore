using ElectronicsStore.Services;
int passed=0;
void Equal(decimal expected,decimal actual){if(expected!=actual)throw new Exception($"Expected {expected}, got {actual}");passed++;}
void Reject(Action a){try{a();}catch(ArgumentException){passed++;return;}throw new Exception("Expected validation error");}
Equal(1000,PriceRules.Total(1000,1,0));Equal(700,PriceRules.Total(1000,1,30));Equal(1800,PriceRules.Total(1000,2,10));Equal(0.01m,PriceRules.Total(0.01m,1,30));Equal(2.68m,PriceRules.Total(1.49m,2,10));Reject(()=>PriceRules.Total(1,0,0));Reject(()=>PriceRules.Total(1,-1,0));Reject(()=>PriceRules.Total(0,1,0));Reject(()=>PriceRules.Total(-1,1,0));Reject(()=>PriceRules.Total(1,1,-0.01m));Reject(()=>PriceRules.Total(1,1,30.01m));Equal(1000000000,PriceRules.Total(1000,1000000,0));Console.WriteLine($"PASS: {passed}/12");
