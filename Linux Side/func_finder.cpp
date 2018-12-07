#include <iostream>
#include <stdlib.h>
#include <string.h>
#include <vector>

using namespace std;

#define SIZE 1024

int f1 = 1;

void ffname(char *line)
{
	int i = 0;
    char c = ' ', c1 = '(';
    string s = line; 
	if(s.find(c1) == string::npos){ 
		f1 = 0;
		return;
	}
	cout <<"Function name is: ";
    for(i = s.find(c) + 1; s[i] != c1; i++){
    	cout<< s[i];
    }
    cout << endl;
    return;
}

int main(int argc, char **argv)
{
    if(argc < 2)
    {
        cout << "Give the filename \n";
        cout << "Usage: " << argv[0] << " filename\n";
        return -1;
    }

    int i, lines =0, funlines =0,count =0, fn =0, flag =0;
	string s;
	vector<string> list;
    char c[SIZE];
    FILE *fd;
    fd = fopen(argv[1],"r");
    while(fgets(c,SIZE,fd))
    {   
        lines++;
        i = 0;
        for(i = 0; i < strlen(c); i++)
        {
            while( c[i] =='\t' || c[i] == ' ')
            {
                i++;
            }
            if( c[i] == '{')
            {
                count++;
				s = c;
                if(flag)
                {
                    funlines++;
                }
                if(count == 1)
                {
                    fn++;
                    flag = 1;
                    ffname(c);
                }
                if(f1)
       				list.push_back(s);
                break;
            }
            else if( c[i] == '}')
            {
                count--;
				s = c;
				if(f1)
					list.push_back(s);
                if(count == 0 && f1)
                { 
                    flag = 0;
					for(auto i = list.begin(); i != list.end(); i++){
						cout<< *i;
					}
					list.clear();
                    funlines = 0;
                }
                else if(count == 0 && f1 == 0)
                {
                	flag = 0;
                	funlines = 0;
                	f1 = 1;
                }
                else
                {
                    funlines++;
                }
                break;
            }
            else if(i == strlen(c) - 1 && flag && f1)
            {
                funlines++;
				s = c;
				list.push_back(s);
                break;
            }
        }
    }
    return 0;
}
