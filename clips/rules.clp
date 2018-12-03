(defrule find-max-value
   (declare (salience 20))
   (team-size (count ?count&:(> ?count 0)))
   ?t-s <- (team-size (count ?old-cnt))
   (hero (name ?name1) (count ?value1))
   (not (hero (count ?value2&:(> ?value2 ?value1))))
   ?h <- (hero (name ?name1))
   =>
   (assert (appendmessage (str-cat ?name1 " - " ?value1)))
   (retract ?h)
   (modify ?t-s (count (- ?old-cnt 1)))
)