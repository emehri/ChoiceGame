git init
git add .
git commit -m "A great and funny way to memorise words of TOEFL, GRE and IELTS exams. Also, the famous books like 1100, 504, ... Also, Spanish verb conjugation!"
gh repo create ChoiceGame --public --source=. --remote=origin
git remote add origin https://github.com/emehri/repository.git
git push -u origin master
pause
