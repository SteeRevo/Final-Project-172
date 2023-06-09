EXTERNAL showWatch()
VAR hasTicket = true

Hey! If it isn't Nicholas! What can I do for you, pal? #charName: Ruther


* {hasTicket} [(show ticket)] 
    I'm here for this. I just want to see it, make sure it's still here? #charName: Nicholas
    ->give_ticket
    
* [Just wanted to have a look around.]
    Well then, take your time. #charName: Ruther

== give_ticket

Sorry pal, but you know the policy. I don't take anything from out back until your loan is repaid in full. #charName: Ruther

Huh? No way! What kind of policy is that? #charName: Nicholas

It's the policy you signed off on. #charName: Ruther

Hey, You gonna waste any more of my time? Total plus interest is $43. You have enough? 

* Fine[ (give him the money)], here it is. #charName: Nicholas

    Ruther counts the notes carefully. #charName: 
    
    Perfect. Let me get that watch for you. #charName: Ruther
    // call fn
    ~ showWatch()
    ->DONE
* No, not right now. #charName: Nicholas

    Well, you remember how this works right? #charName: Ruther
    
    I loaned you $30 for your watch, and to get it back, you have to repay the loan plus interest and fees. #charName: Ruther
    
    Come back with $43, and you can get it back right away, ok?
    ->DONE