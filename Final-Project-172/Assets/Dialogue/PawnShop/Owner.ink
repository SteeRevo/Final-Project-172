EXTERNAL showWatch()
VAR hasTicket = false

Hey! If it isn't Nicholas! What can I do for you, pal? #charName: Ruther


* {hasTicket} [(show ticket)] 
    I'm here for this. I left my watch with you a few days ago? #charName: Nicholas
    ->give_ticket
    
* [Just wanted to have a look around.]
    Well then, take your time. #charName: Ruther

== give_ticket
A few days? You left this with me 3 months ago, remember? You've just been renewing
your loan each month since then. #charName: Ruther

Oh right. I have a lot going on right now, I must've forgot. #charName: Nicholas

Well, hope you didn't forget you need to repay everything. Total plus interest is $43. You have enough? 

* Yes, of course[ (give him the money)], here it is. #charName: Nicholas
    Ruther counts the notes carefully.
    Perfect. Let me get that watch for you. #charName: Ruther
    // call fn
    ~ showWatch()
    ->DONE
* No, not right now. #charName: Nicholas
    Well, you remember how this works right? #charName: Ruther
    I loaned you $30 for your watch, and to get it back, you have to repay the loan plus interest and fees. #charName: Ruther
    Come back with $43, and you can get it back right away, ok?
    ->DONE