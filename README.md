# APIAdventOfCode

docker build -t rootoptal/api-advent-of-code .


docker run -d -p 8080:80 -v //c/work/AdventOfCode/APIAdventOfCode/Puzzles/_2022/Input:/app/Puzzles/_2022/Input -v //c/work/AdventOfCode/APIAdventOfCode/Puzzles/_2021/Input:/app/Puzzles/_2021/input --name turtle_tamer rootoptal/api-advent-of-code
docker run -d -p 1234:80 -v //c/work/AdventOfCode/APIAdventOfCode/Puzzles/_2022/Input:/app/Puzzles/_2022/Input -v //c/work/AdventOfCode/APIAdventOfCode/Puzzles/_2021/Input:/app/Puzzles/_2021/input --name turtle_tamer rootoptal/api-advent-of-code
docker run -d -p 8080:80 --name turtle_tamer rootoptal/api-advent-of-code

