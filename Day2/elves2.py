
r = "rock"
p = "paper"
s = "scissors"

scores = {r:1, p:2, s:3}

lose = 0
draw = 3
win = 6

other_player = {"A":r, "B":p, "C":s}

me = {"X":lose, "Y":draw, "Z":win}

will_lose_against = {r:s, p:r, s:p}
will_win_against = {r:p, p:s, s:r}

# 
# total_score = 0
# 
# with open(r"C:\Users\Barnaby.Dellar\OneDrive - Canon Medical Research Europe Limited\Desktop\elves2.txt") as file_in:
#     for line in file_in:
#         line = line.strip()
#         other_play = other_player[line[0]]
#         my_play = me[line[2]]
# 
#         other_score = scores[other_play]
#         my_score = scores[my_play]
# 
#         if my_play == other_play:
#             result = draw
#         else:
#             if my_play == r and other_play == s:
#                 result = win
#             elif my_play == p and other_play == r:
#                 result = win
#             elif my_play == s and other_play == p:
#                 result = win
#             else:
#                 result = lose
# 
#         total_score += my_score
#         total_score += result
# 
#         print (other_play + " " + str(other_score) + " - " + my_play + " " + str(my_score) + " : "  + str(result))
# print (total_score)

total_score = 0
with open(r"C:\Users\Barnaby.Dellar\OneDrive - Canon Medical Research Europe Limited\Desktop\elves2.txt") as file_in:
    for line in file_in:
        line = line.strip()
        other_play = other_player[line[0]]
        result = me[line[2]]

        if result == draw:
            my_play = other_play
        elif result == lose:
            my_play = will_lose_against[other_play]
        else:
            my_play = will_win_against[other_play]

        my_score = scores[my_play]
        total_score += my_score
        total_score += result

        print (str(result) + " " + str(other_play) + " - " + my_play + " " + str(my_score) + " : "  + str(result))
print (total_score)