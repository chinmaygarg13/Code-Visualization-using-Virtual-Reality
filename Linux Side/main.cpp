#include<iostream>
//#include<conio.h>
using namespace std;

int func(){
	return 1;
	//yoyo
}
int main(){
	//clrscr();
	int number,count=0;
	cout<<"ENTER NUMBER TO CHECK IT IS PRIME OR NOT ";
	//cin>>number;
	number = 5;
	int abc[3] = {1, 2, 3};
	int fval = func();
	for(int a=func();a<=number;a++)
	{
		if(number%a==0)
		{
                	count++;
                }
        }
        if(count==2)
        {
        	cout<<" PRIME NUMBER \n";
        }
        else
        {
        	cout<<" NOT A PRIME NUMBER \n";
        }
	abc[0] = 0;
        //getch();
	return 0;
}

