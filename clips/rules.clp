;(defrule find-match
;	(declare (salience 40))
;	?v <- (villain (name ?v_name)) 
;	?h <- (hero (name ?h_name))
;	=>
;	(assert (appendmessage (str-cat ?v_name " против " ?h_name)))
;)

(defrule find-max-value
   (hero (name ?name1) (count ?value1))
   (not (hero (count ?value2&:(> ?value2 ?value1))))
   =>
   (assert (appendmessage (str-cat ?name1 " - " ?value1)))
)

;(defrule match-pair-for-user 
;	(declare (salience 10))
;	=> 
;	(assert (sendmessage "Вам пары не досталось, но вы там держитесь!"))
;)