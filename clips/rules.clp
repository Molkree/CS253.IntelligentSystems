(defrule find-match
	(declare (salience 40))
	?v <- (villain (name ?v_name)) 
	?h <- (hero (name ?h_name))
	=>
	(assert (appendmessagehalt (str-cat ?v_name " против " ?h_name)))
)

(defrule match-pair-for-user 
	(declare (salience 10))
	=> 
	(assert (sendmessagehalt "Вам пары не досталось, но вы там держитесь!"))
)