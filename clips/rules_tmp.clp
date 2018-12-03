(defrule r1f
    (declare (salience 99))
    (villain (id f1))
    (not (trait (id s7)))
    =>
    (assert (trait (id s7) (name "Телепатия (враг)") (possibility (* (min 1) 0.4))))
)

(defrule r1
    (declare (salience 99))
    (villain (id f1))
    (trait (id s7) (possibility ?old-coef))
    (not (already-increased (id tr1)))
    ?t <- (trait (id s7))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.4))))
    (assert (already-increased (id tr1)))
)

(defrule r2f
    (declare (salience 99))
    (villain (id f1))
    (not (trait (id s11)))
    =>
    (assert (trait (id s11) (name "Сверхсила (враг)") (possibility (* (min 1) 0.8))))
)

(defrule r2
    (declare (salience 99))
    (villain (id f1))
    (trait (id s11) (possibility ?old-coef))
    (not (already-increased (id tr2)))
    ?t <- (trait (id s11))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.8))))
    (assert (already-increased (id tr2)))
)

(defrule r3f
    (declare (salience 99))
    (villain (id f1))
    (not (trait (id s13)))
    =>
    (assert (trait (id s13) (name "Неуязвимость (враг)") (possibility (* (min 1) 0.9))))
)

(defrule r3
    (declare (salience 99))
    (villain (id f1))
    (trait (id s13) (possibility ?old-coef))
    (not (already-increased (id tr3)))
    ?t <- (trait (id s13))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.9))))
    (assert (already-increased (id tr3)))
)

(defrule r4f
    (declare (salience 99))
    (villain (id f1))
    (not (trait (id s15)))
    =>
    (assert (trait (id s15) (name "Левитация (враг)") (possibility (* (min 1) 0.1))))
)

(defrule r4
    (declare (salience 99))
    (villain (id f1))
    (trait (id s15) (possibility ?old-coef))
    (not (already-increased (id tr4)))
    ?t <- (trait (id s15))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.1))))
    (assert (already-increased (id tr4)))
)

(defrule r5f
    (declare (salience 99))
    (villain (id f2))
    (not (trait (id s7)))
    =>
    (assert (trait (id s7) (name "Телепатия (враг)") (possibility (* (min 1) 0.9))))
)

(defrule r5
    (declare (salience 99))
    (villain (id f2))
    (trait (id s7) (possibility ?old-coef))
    (not (already-increased (id tr5)))
    ?t <- (trait (id s7))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.9))))
    (assert (already-increased (id tr5)))
)

(defrule r6f
    (declare (salience 99))
    (villain (id f2))
    (not (trait (id s9)))
    =>
    (assert (trait (id s9) (name "Устойчивость к телепатии (враг)") (possibility (* (min 1) 0.99))))
)

(defrule r6
    (declare (salience 99))
    (villain (id f2))
    (trait (id s9) (possibility ?old-coef))
    (not (already-increased (id tr6)))
    ?t <- (trait (id s9))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.99))))
    (assert (already-increased (id tr6)))
)

(defrule r7f
    (declare (salience 99))
    (villain (id f2))
    (not (trait (id s15)))
    =>
    (assert (trait (id s15) (name "Левитация (враг)") (possibility (* (min 1) 0.4))))
)

(defrule r7
    (declare (salience 99))
    (villain (id f2))
    (trait (id s15) (possibility ?old-coef))
    (not (already-increased (id tr7)))
    ?t <- (trait (id s15))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.4))))
    (assert (already-increased (id tr7)))
)

(defrule r8f
    (declare (salience 99))
    (villain (id f3))
    (not (trait (id s7)))
    =>
    (assert (trait (id s7) (name "Телепатия (враг)") (possibility (* (min 1) 0.8))))
)

(defrule r8
    (declare (salience 99))
    (villain (id f3))
    (trait (id s7) (possibility ?old-coef))
    (not (already-increased (id tr8)))
    ?t <- (trait (id s7))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.8))))
    (assert (already-increased (id tr8)))
)

(defrule r9f
    (declare (salience 99))
    (villain (id f3))
    (not (trait (id s11)))
    =>
    (assert (trait (id s11) (name "Сверхсила (враг)") (possibility (* (min 1) 0.3))))
)

(defrule r9
    (declare (salience 99))
    (villain (id f3))
    (trait (id s11) (possibility ?old-coef))
    (not (already-increased (id tr9)))
    ?t <- (trait (id s11))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.3))))
    (assert (already-increased (id tr9)))
)

(defrule r10f
    (declare (salience 99))
    (villain (id f3))
    (not (trait (id s13)))
    =>
    (assert (trait (id s13) (name "Неуязвимость (враг)") (possibility (* (min 1) 0.9))))
)

(defrule r10
    (declare (salience 99))
    (villain (id f3))
    (trait (id s13) (possibility ?old-coef))
    (not (already-increased (id tr10)))
    ?t <- (trait (id s13))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.9))))
    (assert (already-increased (id tr10)))
)

(defrule r11f
    (declare (salience 99))
    (villain (id f3))
    (not (trait (id s17)))
    =>
    (assert (trait (id s17) (name "Ловкость (враг)") (possibility (* (min 1) 0.7))))
)

(defrule r11
    (declare (salience 99))
    (villain (id f3))
    (trait (id s17) (possibility ?old-coef))
    (not (already-increased (id tr11)))
    ?t <- (trait (id s17))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.7))))
    (assert (already-increased (id tr11)))
)

(defrule r12f
    (declare (salience 99))
    (villain (id f3))
    (not (trait (id s23)))
    =>
    (assert (trait (id s23) (name "Магия (враг)") (possibility (* (min 1) 0.8))))
)

(defrule r12
    (declare (salience 99))
    (villain (id f3))
    (trait (id s23) (possibility ?old-coef))
    (not (already-increased (id tr12)))
    ?t <- (trait (id s23))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.8))))
    (assert (already-increased (id tr12)))
)

(defrule r13f
    (declare (salience 99))
    (villain (id f3))
    (not (trait (id s25)))
    =>
    (assert (trait (id s25) (name "Шпионаж (враг)") (possibility (* (min 1) 0.4))))
)

(defrule r13
    (declare (salience 99))
    (villain (id f3))
    (trait (id s25) (possibility ?old-coef))
    (not (already-increased (id tr13)))
    ?t <- (trait (id s25))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.4))))
    (assert (already-increased (id tr13)))
)

(defrule r14f
    (declare (salience 99))
    (villain (id f4))
    (not (trait (id s9)))
    =>
    (assert (trait (id s9) (name "Устойчивость к телепатии (враг)") (possibility (* (min 1) 0.9))))
)

(defrule r14
    (declare (salience 99))
    (villain (id f4))
    (trait (id s9) (possibility ?old-coef))
    (not (already-increased (id tr14)))
    ?t <- (trait (id s9))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.9))))
    (assert (already-increased (id tr14)))
)

(defrule r15f
    (declare (salience 99))
    (villain (id f4))
    (not (trait (id s17)))
    =>
    (assert (trait (id s17) (name "Ловкость (враг)") (possibility (* (min 1) 0.6))))
)

(defrule r15
    (declare (salience 99))
    (villain (id f4))
    (trait (id s17) (possibility ?old-coef))
    (not (already-increased (id tr15)))
    ?t <- (trait (id s17))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.6))))
    (assert (already-increased (id tr15)))
)

(defrule r16f
    (declare (salience 99))
    (villain (id f4))
    (not (trait (id s25)))
    =>
    (assert (trait (id s25) (name "Шпионаж (враг)") (possibility (* (min 1) 0.7))))
)

(defrule r16
    (declare (salience 99))
    (villain (id f4))
    (trait (id s25) (possibility ?old-coef))
    (not (already-increased (id tr16)))
    ?t <- (trait (id s25))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.7))))
    (assert (already-increased (id tr16)))
)

(defrule r17f
    (declare (salience 99))
    (villain (id f4))
    (not (trait (id s27)))
    =>
    (assert (trait (id s27) (name "Боевые искусства (враг)") (possibility (* (min 1) 0.5))))
)

(defrule r17
    (declare (salience 99))
    (villain (id f4))
    (trait (id s27) (possibility ?old-coef))
    (not (already-increased (id tr17)))
    ?t <- (trait (id s27))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.5))))
    (assert (already-increased (id tr17)))
)

(defrule r18f
    (declare (salience 99))
    (villain (id f5))
    (not (trait (id s7)))
    =>
    (assert (trait (id s7) (name "Телепатия (враг)") (possibility (* (min 1) 0.8))))
)

(defrule r18
    (declare (salience 99))
    (villain (id f5))
    (trait (id s7) (possibility ?old-coef))
    (not (already-increased (id tr18)))
    ?t <- (trait (id s7))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.8))))
    (assert (already-increased (id tr18)))
)

(defrule r19f
    (declare (salience 99))
    (villain (id f5))
    (not (trait (id s11)))
    =>
    (assert (trait (id s11) (name "Сверхсила (враг)") (possibility (* (min 1) 0.7))))
)

(defrule r19
    (declare (salience 99))
    (villain (id f5))
    (trait (id s11) (possibility ?old-coef))
    (not (already-increased (id tr19)))
    ?t <- (trait (id s11))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.7))))
    (assert (already-increased (id tr19)))
)

(defrule r20f
    (declare (salience 99))
    (villain (id f5))
    (not (trait (id s17)))
    =>
    (assert (trait (id s17) (name "Ловкость (враг)") (possibility (* (min 1) 0.4))))
)

(defrule r20
    (declare (salience 99))
    (villain (id f5))
    (trait (id s17) (possibility ?old-coef))
    (not (already-increased (id tr20)))
    ?t <- (trait (id s17))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.4))))
    (assert (already-increased (id tr20)))
)

(defrule r21f
    (declare (salience 99))
    (villain (id f5))
    (not (trait (id s19)))
    =>
    (assert (trait (id s19) (name "Сверхскорость (враг)") (possibility (* (min 1) 0.3))))
)

(defrule r21
    (declare (salience 99))
    (villain (id f5))
    (trait (id s19) (possibility ?old-coef))
    (not (already-increased (id tr21)))
    ?t <- (trait (id s19))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.3))))
    (assert (already-increased (id tr21)))
)

(defrule r22f
    (declare (salience 99))
    (villain (id f5))
    (not (trait (id s23)))
    =>
    (assert (trait (id s23) (name "Магия (враг)") (possibility (* (min 1) 0.8))))
)

(defrule r22
    (declare (salience 99))
    (villain (id f5))
    (trait (id s23) (possibility ?old-coef))
    (not (already-increased (id tr22)))
    ?t <- (trait (id s23))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.8))))
    (assert (already-increased (id tr22)))
)

(defrule r23f
    (declare (salience 99))
    (villain (id f6))
    (not (trait (id s13)))
    =>
    (assert (trait (id s13) (name "Неуязвимость (враг)") (possibility (* (min 1) 0.9))))
)

(defrule r23
    (declare (salience 99))
    (villain (id f6))
    (trait (id s13) (possibility ?old-coef))
    (not (already-increased (id tr23)))
    ?t <- (trait (id s13))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.9))))
    (assert (already-increased (id tr23)))
)

(defrule r24f
    (declare (salience 99))
    (villain (id f6))
    (not (trait (id s7)))
    =>
    (assert (trait (id s7) (name "Телепатия (враг)") (possibility (* (min 1) 0.7))))
)

(defrule r24
    (declare (salience 99))
    (villain (id f6))
    (trait (id s7) (possibility ?old-coef))
    (not (already-increased (id tr24)))
    ?t <- (trait (id s7))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.7))))
    (assert (already-increased (id tr24)))
)

(defrule r25f
    (declare (salience 99))
    (villain (id f6))
    (not (trait (id s11)))
    =>
    (assert (trait (id s11) (name "Сверхсила (враг)") (possibility (* (min 1) 0.6))))
)

(defrule r25
    (declare (salience 99))
    (villain (id f6))
    (trait (id s11) (possibility ?old-coef))
    (not (already-increased (id tr25)))
    ?t <- (trait (id s11))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.6))))
    (assert (already-increased (id tr25)))
)

(defrule r26f
    (declare (salience 99))
    (villain (id f6))
    (not (trait (id s15)))
    =>
    (assert (trait (id s15) (name "Левитация (враг)") (possibility (* (min 1) 0.4))))
)

(defrule r26
    (declare (salience 99))
    (villain (id f6))
    (trait (id s15) (possibility ?old-coef))
    (not (already-increased (id tr26)))
    ?t <- (trait (id s15))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.4))))
    (assert (already-increased (id tr26)))
)

(defrule r27f
    (declare (salience 99))
    (villain (id f6))
    (not (trait (id s27)))
    =>
    (assert (trait (id s27) (name "Боевые искусства (враг)") (possibility (* (min 1) 0.7))))
)

(defrule r27
    (declare (salience 99))
    (villain (id f6))
    (trait (id s27) (possibility ?old-coef))
    (not (already-increased (id tr27)))
    ?t <- (trait (id s27))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.7))))
    (assert (already-increased (id tr27)))
)

(defrule r28f
    (declare (salience 99))
    (villain (id f6))
    (not (trait (id s23)))
    =>
    (assert (trait (id s23) (name "Магия (враг)") (possibility (* (min 1) 0.7))))
)

(defrule r28
    (declare (salience 99))
    (villain (id f6))
    (trait (id s23) (possibility ?old-coef))
    (not (already-increased (id tr28)))
    ?t <- (trait (id s23))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.7))))
    (assert (already-increased (id tr28)))
)

(defrule r29f
    (declare (salience 99))
    (villain (id f7))
    (not (trait (id s11)))
    =>
    (assert (trait (id s11) (name "Сверхсила (враг)") (possibility (* (min 1) 0.9))))
)

(defrule r29
    (declare (salience 99))
    (villain (id f7))
    (trait (id s11) (possibility ?old-coef))
    (not (already-increased (id tr29)))
    ?t <- (trait (id s11))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.9))))
    (assert (already-increased (id tr29)))
)

(defrule r30f
    (declare (salience 99))
    (villain (id f8))
    (not (trait (id s11)))
    =>
    (assert (trait (id s11) (name "Сверхсила (враг)") (possibility (* (min 1) 0.7))))
)

(defrule r30
    (declare (salience 99))
    (villain (id f8))
    (trait (id s11) (possibility ?old-coef))
    (not (already-increased (id tr30)))
    ?t <- (trait (id s11))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.7))))
    (assert (already-increased (id tr30)))
)

(defrule r31f
    (declare (salience 99))
    (villain (id f8))
    (not (trait (id s17)))
    =>
    (assert (trait (id s17) (name "Ловкость (враг)") (possibility (* (min 1) 0.6))))
)

(defrule r31
    (declare (salience 99))
    (villain (id f8))
    (trait (id s17) (possibility ?old-coef))
    (not (already-increased (id tr31)))
    ?t <- (trait (id s17))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.6))))
    (assert (already-increased (id tr31)))
)

(defrule r32f
    (declare (salience 99))
    (villain (id f8))
    (not (trait (id s19)))
    =>
    (assert (trait (id s19) (name "Сверхскорость (враг)") (possibility (* (min 1) 0.7))))
)

(defrule r32
    (declare (salience 99))
    (villain (id f8))
    (trait (id s19) (possibility ?old-coef))
    (not (already-increased (id tr32)))
    ?t <- (trait (id s19))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.7))))
    (assert (already-increased (id tr32)))
)

(defrule r33f
    (declare (salience 99))
    (villain (id f8))
    (not (trait (id s25)))
    =>
    (assert (trait (id s25) (name "Шпионаж (враг)") (possibility (* (min 1) 0.6))))
)

(defrule r33
    (declare (salience 99))
    (villain (id f8))
    (trait (id s25) (possibility ?old-coef))
    (not (already-increased (id tr33)))
    ?t <- (trait (id s25))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.6))))
    (assert (already-increased (id tr33)))
)

(defrule r34f
    (declare (salience 99))
    (villain (id f8))
    (not (trait (id s27)))
    =>
    (assert (trait (id s27) (name "Боевые искусства (враг)") (possibility (* (min 1) 0.7))))
)

(defrule r34
    (declare (salience 99))
    (villain (id f8))
    (trait (id s27) (possibility ?old-coef))
    (not (already-increased (id tr34)))
    ?t <- (trait (id s27))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.7))))
    (assert (already-increased (id tr34)))
)

(defrule r35f
    (declare (salience 99))
    (villain (id f9))
    (not (trait (id s11)))
    =>
    (assert (trait (id s11) (name "Сверхсила (враг)") (possibility (* (min 1) 0.9))))
)

(defrule r35
    (declare (salience 99))
    (villain (id f9))
    (trait (id s11) (possibility ?old-coef))
    (not (already-increased (id tr35)))
    ?t <- (trait (id s11))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.9))))
    (assert (already-increased (id tr35)))
)

(defrule r36f
    (declare (salience 99))
    (villain (id f9))
    (not (trait (id s17)))
    =>
    (assert (trait (id s17) (name "Ловкость (враг)") (possibility (* (min 1) 0.7))))
)

(defrule r36
    (declare (salience 99))
    (villain (id f9))
    (trait (id s17) (possibility ?old-coef))
    (not (already-increased (id tr36)))
    ?t <- (trait (id s17))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.7))))
    (assert (already-increased (id tr36)))
)

(defrule r37f
    (declare (salience 99))
    (villain (id f9))
    (not (trait (id s19)))
    =>
    (assert (trait (id s19) (name "Сверхскорость (враг)") (possibility (* (min 1) 0.6))))
)

(defrule r37
    (declare (salience 99))
    (villain (id f9))
    (trait (id s19) (possibility ?old-coef))
    (not (already-increased (id tr37)))
    ?t <- (trait (id s19))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.6))))
    (assert (already-increased (id tr37)))
)

(defrule r38f
    (declare (salience 99))
    (villain (id f9))
    (not (trait (id s25)))
    =>
    (assert (trait (id s25) (name "Шпионаж (враг)") (possibility (* (min 1) 0.5))))
)

(defrule r38
    (declare (salience 99))
    (villain (id f9))
    (trait (id s25) (possibility ?old-coef))
    (not (already-increased (id tr38)))
    ?t <- (trait (id s25))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.5))))
    (assert (already-increased (id tr38)))
)

(defrule r39f
    (declare (salience 99))
    (villain (id f10))
    (not (trait (id s11)))
    =>
    (assert (trait (id s11) (name "Сверхсила (враг)") (possibility (* (min 1) 0.8))))
)

(defrule r39
    (declare (salience 99))
    (villain (id f10))
    (trait (id s11) (possibility ?old-coef))
    (not (already-increased (id tr39)))
    ?t <- (trait (id s11))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.8))))
    (assert (already-increased (id tr39)))
)

(defrule r40f
    (declare (salience 99))
    (villain (id f10))
    (not (trait (id s17)))
    =>
    (assert (trait (id s17) (name "Ловкость (враг)") (possibility (* (min 1) 0.7))))
)

(defrule r40
    (declare (salience 99))
    (villain (id f10))
    (trait (id s17) (possibility ?old-coef))
    (not (already-increased (id tr40)))
    ?t <- (trait (id s17))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.7))))
    (assert (already-increased (id tr40)))
)

(defrule r41f
    (declare (salience 99))
    (villain (id f11))
    (not (trait (id s11)))
    =>
    (assert (trait (id s11) (name "Сверхсила (враг)") (possibility (* (min 1) 0.9))))
)

(defrule r41
    (declare (salience 99))
    (villain (id f11))
    (trait (id s11) (possibility ?old-coef))
    (not (already-increased (id tr41)))
    ?t <- (trait (id s11))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.9))))
    (assert (already-increased (id tr41)))
)

(defrule r42f
    (declare (salience 99))
    (villain (id f11))
    (not (trait (id s15)))
    =>
    (assert (trait (id s15) (name "Левитация (враг)") (possibility (* (min 1) 0.7))))
)

(defrule r42
    (declare (salience 99))
    (villain (id f11))
    (trait (id s15) (possibility ?old-coef))
    (not (already-increased (id tr42)))
    ?t <- (trait (id s15))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.7))))
    (assert (already-increased (id tr42)))
)

(defrule r43f
    (declare (salience 99))
    (villain (id f11))
    (not (trait (id s19)))
    =>
    (assert (trait (id s19) (name "Сверхскорость (враг)") (possibility (* (min 1) 0.9))))
)

(defrule r43
    (declare (salience 99))
    (villain (id f11))
    (trait (id s19) (possibility ?old-coef))
    (not (already-increased (id tr43)))
    ?t <- (trait (id s19))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.9))))
    (assert (already-increased (id tr43)))
)

(defrule r44f
    (declare (salience 99))
    (villain (id f12))
    (not (trait (id s11)))
    =>
    (assert (trait (id s11) (name "Сверхсила (враг)") (possibility (* (min 1) 0.9))))
)

(defrule r44
    (declare (salience 99))
    (villain (id f12))
    (trait (id s11) (possibility ?old-coef))
    (not (already-increased (id tr44)))
    ?t <- (trait (id s11))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.9))))
    (assert (already-increased (id tr44)))
)

(defrule r45f
    (declare (salience 99))
    (villain (id f12))
    (not (trait (id s17)))
    =>
    (assert (trait (id s17) (name "Ловкость (враг)") (possibility (* (min 1) 0.8))))
)

(defrule r45
    (declare (salience 99))
    (villain (id f12))
    (trait (id s17) (possibility ?old-coef))
    (not (already-increased (id tr45)))
    ?t <- (trait (id s17))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1) 0.8))))
    (assert (already-increased (id tr45)))
)

(defrule r46f
    (declare (salience 99))
    (trait (id s7) (possibility ?s7-coef))
    (trait (id s11) (possibility ?s11-coef))
    (trait (id s13) (possibility ?s13-coef))
    (trait (id s15) (possibility ?s15-coef))
    (not (trait (id s1)))
    =>
    (assert (trait (id s1) (name "Имбовый класс") (possibility (* (min 1 ?s7-coef ?s11-coef ?s13-coef ?s15-coef) 0.99))))
)

(defrule r46
    (declare (salience 99))
    (trait (id s7) (possibility ?s7-coef))
    (trait (id s11) (possibility ?s11-coef))
    (trait (id s13) (possibility ?s13-coef))
    (trait (id s15) (possibility ?s15-coef))
    (trait (id s1) (possibility ?old-coef))
    (not (already-increased (id tr46)))
    ?t <- (trait (id s1))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s7-coef ?s11-coef ?s13-coef ?s15-coef) 0.99))))
    (assert (already-increased (id tr46)))
)

(defrule r47f
    (declare (salience 99))
    (trait (id s11) (possibility ?s11-coef))
    (trait (id s13) (possibility ?s13-coef))
    (not (trait (id s2)))
    =>
    (assert (trait (id s2) (name "Класс Танк") (possibility (* (min 1 ?s11-coef ?s13-coef) 0.9))))
)

(defrule r47
    (declare (salience 99))
    (trait (id s11) (possibility ?s11-coef))
    (trait (id s13) (possibility ?s13-coef))
    (trait (id s2) (possibility ?old-coef))
    (not (already-increased (id tr47)))
    ?t <- (trait (id s2))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s11-coef ?s13-coef) 0.9))))
    (assert (already-increased (id tr47)))
)

(defrule r48f
    (declare (salience 99))
    (trait (id s17) (possibility ?s17-coef))
    (trait (id s25) (possibility ?s25-coef))
    (not (trait (id s3)))
    =>
    (assert (trait (id s3) (name "Класс Син (Убийца)") (possibility (* (min 1 ?s17-coef ?s25-coef) 0.7))))
)

(defrule r48
    (declare (salience 99))
    (trait (id s17) (possibility ?s17-coef))
    (trait (id s25) (possibility ?s25-coef))
    (trait (id s3) (possibility ?old-coef))
    (not (already-increased (id tr48)))
    ?t <- (trait (id s3))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s17-coef ?s25-coef) 0.7))))
    (assert (already-increased (id tr48)))
)

(defrule r49f
    (declare (salience 99))
    (trait (id s11) (possibility ?s11-coef))
    (not (trait (id s4)))
    =>
    (assert (trait (id s4) (name "Ближний бой") (possibility (* (min 1 ?s11-coef) 0.6))))
)

(defrule r49
    (declare (salience 99))
    (trait (id s11) (possibility ?s11-coef))
    (trait (id s4) (possibility ?old-coef))
    (not (already-increased (id tr49)))
    ?t <- (trait (id s4))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s11-coef) 0.6))))
    (assert (already-increased (id tr49)))
)

(defrule r50f
    (declare (salience 99))
    (trait (id s27) (possibility ?s27-coef))
    (not (trait (id s4)))
    =>
    (assert (trait (id s4) (name "Ближний бой") (possibility (* (min 1 ?s27-coef) 0.7))))
)

(defrule r50
    (declare (salience 99))
    (trait (id s27) (possibility ?s27-coef))
    (trait (id s4) (possibility ?old-coef))
    (not (already-increased (id tr50)))
    ?t <- (trait (id s4))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s27-coef) 0.7))))
    (assert (already-increased (id tr50)))
)

(defrule r51f
    (declare (salience 99))
    (trait (id s29) (possibility ?s29-coef))
    (not (trait (id s5)))
    =>
    (assert (trait (id s5) (name "Дальний бой") (possibility (* (min 1 ?s29-coef) 0.7))))
)

(defrule r51
    (declare (salience 99))
    (trait (id s29) (possibility ?s29-coef))
    (trait (id s5) (possibility ?old-coef))
    (not (already-increased (id tr51)))
    ?t <- (trait (id s5))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s29-coef) 0.7))))
    (assert (already-increased (id tr51)))
)

(defrule r52f
    (declare (salience 99))
    (trait (id s23) (possibility ?s23-coef))
    (not (trait (id s5)))
    =>
    (assert (trait (id s5) (name "Дальний бой") (possibility (* (min 1 ?s23-coef) 0.7))))
)

(defrule r52
    (declare (salience 99))
    (trait (id s23) (possibility ?s23-coef))
    (trait (id s5) (possibility ?old-coef))
    (not (already-increased (id tr52)))
    ?t <- (trait (id s5))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s23-coef) 0.7))))
    (assert (already-increased (id tr52)))
)

(defrule r53f
    (declare (salience 99))
    (trait (id s21) (possibility ?s21-coef))
    (not (trait (id s6)))
    =>
    (assert (trait (id s6) (name "Поддержка") (possibility (* (min 1 ?s21-coef) 0.6))))
)

(defrule r53
    (declare (salience 99))
    (trait (id s21) (possibility ?s21-coef))
    (trait (id s6) (possibility ?old-coef))
    (not (already-increased (id tr53)))
    ?t <- (trait (id s6))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s21-coef) 0.6))))
    (assert (already-increased (id tr53)))
)

(defrule r54f
    (declare (salience 99))
    (trait (id s2) (possibility ?s2-coef))
    (not (trait (id s12)))
    =>
    (assert (trait (id s12) (name "Сверхсила (герой)") (possibility (* (min 1 ?s2-coef) 0.8))))
)

(defrule r54
    (declare (salience 99))
    (trait (id s2) (possibility ?s2-coef))
    (trait (id s12) (possibility ?old-coef))
    (not (already-increased (id tr54)))
    ?t <- (trait (id s12))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s2-coef) 0.8))))
    (assert (already-increased (id tr54)))
)

(defrule r55f
    (declare (salience 99))
    (trait (id s2) (possibility ?s2-coef))
    (not (trait (id s13)))
    =>
    (assert (trait (id s13) (name "Неуязвимость (враг)") (possibility (* (min 1 ?s2-coef) 0.85))))
)

(defrule r55
    (declare (salience 99))
    (trait (id s2) (possibility ?s2-coef))
    (trait (id s13) (possibility ?old-coef))
    (not (already-increased (id tr55)))
    ?t <- (trait (id s13))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s2-coef) 0.85))))
    (assert (already-increased (id tr55)))
)

(defrule r56f
    (declare (salience 99))
    (trait (id s3) (possibility ?s3-coef))
    (not (trait (id s24)))
    =>
    (assert (trait (id s24) (name "Магия (герой)") (possibility (* (min 1 ?s3-coef) 0.6))))
)

(defrule r56
    (declare (salience 99))
    (trait (id s3) (possibility ?s3-coef))
    (trait (id s24) (possibility ?old-coef))
    (not (already-increased (id tr56)))
    ?t <- (trait (id s24))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s3-coef) 0.6))))
    (assert (already-increased (id tr56)))
)

(defrule r57f
    (declare (salience 99))
    (trait (id s3) (possibility ?s3-coef))
    (not (trait (id s30)))
    =>
    (assert (trait (id s30) (name "Стрелок (герой)") (possibility (* (min 1 ?s3-coef) 0.7))))
)

(defrule r57
    (declare (salience 99))
    (trait (id s3) (possibility ?s3-coef))
    (trait (id s30) (possibility ?old-coef))
    (not (already-increased (id tr57)))
    ?t <- (trait (id s30))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s3-coef) 0.7))))
    (assert (already-increased (id tr57)))
)

(defrule r58f
    (declare (salience 99))
    (trait (id s4) (possibility ?s4-coef))
    (not (trait (id s14)))
    =>
    (assert (trait (id s14) (name "Неуязвимость (герой)") (possibility (* (min 1 ?s4-coef) 0.8))))
)

(defrule r58
    (declare (salience 99))
    (trait (id s4) (possibility ?s4-coef))
    (trait (id s14) (possibility ?old-coef))
    (not (already-increased (id tr58)))
    ?t <- (trait (id s14))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s4-coef) 0.8))))
    (assert (already-increased (id tr58)))
)

(defrule r59f
    (declare (salience 99))
    (trait (id s4) (possibility ?s4-coef))
    (not (trait (id s28)))
    =>
    (assert (trait (id s28) (name "Боевые искусства (герой)") (possibility (* (min 1 ?s4-coef) 0.6))))
)

(defrule r59
    (declare (salience 99))
    (trait (id s4) (possibility ?s4-coef))
    (trait (id s28) (possibility ?old-coef))
    (not (already-increased (id tr59)))
    ?t <- (trait (id s28))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s4-coef) 0.6))))
    (assert (already-increased (id tr59)))
)

(defrule r60f
    (declare (salience 99))
    (trait (id s5) (possibility ?s5-coef))
    (not (trait (id s18)))
    =>
    (assert (trait (id s18) (name "Ловкость (герой)") (possibility (* (min 1 ?s5-coef) 0.6))))
)

(defrule r60
    (declare (salience 99))
    (trait (id s5) (possibility ?s5-coef))
    (trait (id s18) (possibility ?old-coef))
    (not (already-increased (id tr60)))
    ?t <- (trait (id s18))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s5-coef) 0.6))))
    (assert (already-increased (id tr60)))
)

(defrule r61f
    (declare (salience 99))
    (trait (id s6) (possibility ?s6-coef))
    (not (trait (id s12)))
    =>
    (assert (trait (id s12) (name "Сверхсила (герой)") (possibility (* (min 1 ?s6-coef) 0.3))))
)

(defrule r61
    (declare (salience 99))
    (trait (id s6) (possibility ?s6-coef))
    (trait (id s12) (possibility ?old-coef))
    (not (already-increased (id tr61)))
    ?t <- (trait (id s12))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s6-coef) 0.3))))
    (assert (already-increased (id tr61)))
)

(defrule r62f
    (declare (salience 99))
    (trait (id s7) (possibility ?s7-coef))
    (not (trait (id s10)))
    =>
    (assert (trait (id s10) (name "Устойчивость к телепатии (герой)") (possibility (* (min 1 ?s7-coef) 0.9))))
)

(defrule r62
    (declare (salience 99))
    (trait (id s7) (possibility ?s7-coef))
    (trait (id s10) (possibility ?old-coef))
    (not (already-increased (id tr62)))
    ?t <- (trait (id s10))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s7-coef) 0.9))))
    (assert (already-increased (id tr62)))
)

(defrule r63f
    (declare (salience 99))
    (trait (id s9) (possibility ?s9-coef))
    (not (trait (id s24)))
    =>
    (assert (trait (id s24) (name "Магия (герой)") (possibility (* (min 1 ?s9-coef) 0.7))))
)

(defrule r63
    (declare (salience 99))
    (trait (id s9) (possibility ?s9-coef))
    (trait (id s24) (possibility ?old-coef))
    (not (already-increased (id tr63)))
    ?t <- (trait (id s24))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s9-coef) 0.7))))
    (assert (already-increased (id tr63)))
)

(defrule r64f
    (declare (salience 99))
    (trait (id s17) (possibility ?s17-coef))
    (not (trait (id s20)))
    =>
    (assert (trait (id s20) (name "Сверхскорость (герой)") (possibility (* (min 1 ?s17-coef) 0.6))))
)

(defrule r64
    (declare (salience 99))
    (trait (id s17) (possibility ?s17-coef))
    (trait (id s20) (possibility ?old-coef))
    (not (already-increased (id tr64)))
    ?t <- (trait (id s20))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s17-coef) 0.6))))
    (assert (already-increased (id tr64)))
)

(defrule r65f
    (declare (salience 99))
    (trait (id s21) (possibility ?s21-coef))
    (not (trait (id s26)))
    =>
    (assert (trait (id s26) (name "Шпионаж (герой)") (possibility (* (min 1 ?s21-coef) 0.7))))
)

(defrule r65
    (declare (salience 99))
    (trait (id s21) (possibility ?s21-coef))
    (trait (id s26) (possibility ?old-coef))
    (not (already-increased (id tr65)))
    ?t <- (trait (id s26))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s21-coef) 0.7))))
    (assert (already-increased (id tr65)))
)

(defrule r66f
    (declare (salience 99))
    (trait (id s23) (possibility ?s23-coef))
    (not (trait (id s22)))
    =>
    (assert (trait (id s22) (name "Защитное поле (герой)") (possibility (* (min 1 ?s23-coef) 0.8))))
)

(defrule r66
    (declare (salience 99))
    (trait (id s23) (possibility ?s23-coef))
    (trait (id s22) (possibility ?old-coef))
    (not (already-increased (id tr66)))
    ?t <- (trait (id s22))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s23-coef) 0.8))))
    (assert (already-increased (id tr66)))
)

(defrule r67f
    (declare (salience 99))
    (trait (id s1) (possibility ?s1-coef))
    (not (hero (id t1)))
    =>
    (assert (hero (id t1) (name "Капитан Марвел") (count 1) (possibility (* (min 1 ?s1-coef) 0.9))))
)

(defrule r67
    (declare (salience 99))
    (trait (id s1) (possibility ?s1-coef))
    (hero (id t1) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr67)))
    ?h <- (hero (id t1))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s1-coef) 0.9))))
    (assert (already-increased (id hr67)))
)

(defrule r68f
    (declare (salience 99))
    (trait (id s12) (possibility ?s12-coef))
    (not (hero (id t1)))
    =>
    (assert (hero (id t1) (name "Капитан Марвел") (count 1) (possibility (* (min 1 ?s12-coef) 0.7))))
)

(defrule r68
    (declare (salience 99))
    (trait (id s12) (possibility ?s12-coef))
    (hero (id t1) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr68)))
    ?h <- (hero (id t1))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s12-coef) 0.7))))
    (assert (already-increased (id hr68)))
)

(defrule r69f
    (declare (salience 99))
    (trait (id s14) (possibility ?s14-coef))
    (not (hero (id t1)))
    =>
    (assert (hero (id t1) (name "Капитан Марвел") (count 1) (possibility (* (min 1 ?s14-coef) 0.6))))
)

(defrule r69
    (declare (salience 99))
    (trait (id s14) (possibility ?s14-coef))
    (hero (id t1) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr69)))
    ?h <- (hero (id t1))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s14-coef) 0.6))))
    (assert (already-increased (id hr69)))
)

(defrule r70f
    (declare (salience 99))
    (trait (id s16) (possibility ?s16-coef))
    (not (hero (id t1)))
    =>
    (assert (hero (id t1) (name "Капитан Марвел") (count 1) (possibility (* (min 1 ?s16-coef) 0.7))))
)

(defrule r70
    (declare (salience 99))
    (trait (id s16) (possibility ?s16-coef))
    (hero (id t1) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr70)))
    ?h <- (hero (id t1))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s16-coef) 0.7))))
    (assert (already-increased (id hr70)))
)

(defrule r71f
    (declare (salience 99))
    (trait (id s12) (possibility ?s12-coef))
    (not (hero (id t2)))
    =>
    (assert (hero (id t2) (name "Тор") (count 1) (possibility (* (min 1 ?s12-coef) 0.8))))
)

(defrule r71
    (declare (salience 99))
    (trait (id s12) (possibility ?s12-coef))
    (hero (id t2) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr71)))
    ?h <- (hero (id t2))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s12-coef) 0.8))))
    (assert (already-increased (id hr71)))
)

(defrule r72f
    (declare (salience 99))
    (trait (id s16) (possibility ?s16-coef))
    (not (hero (id t2)))
    =>
    (assert (hero (id t2) (name "Тор") (count 1) (possibility (* (min 1 ?s16-coef) 0.2))))
)

(defrule r72
    (declare (salience 99))
    (trait (id s16) (possibility ?s16-coef))
    (hero (id t2) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr72)))
    ?h <- (hero (id t2))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s16-coef) 0.2))))
    (assert (already-increased (id hr72)))
)

(defrule r73f
    (declare (salience 99))
    (trait (id s24) (possibility ?s24-coef))
    (not (hero (id t2)))
    =>
    (assert (hero (id t2) (name "Тор") (count 1) (possibility (* (min 1 ?s24-coef) 0.6))))
)

(defrule r73
    (declare (salience 99))
    (trait (id s24) (possibility ?s24-coef))
    (hero (id t2) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr73)))
    ?h <- (hero (id t2))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s24-coef) 0.6))))
    (assert (already-increased (id hr73)))
)

(defrule r74f
    (declare (salience 99))
    (trait (id s16) (possibility ?s16-coef))
    (not (hero (id t3)))
    =>
    (assert (hero (id t3) (name "Железный человек") (count 1) (possibility (* (min 1 ?s16-coef) 0.4))))
)

(defrule r74
    (declare (salience 99))
    (trait (id s16) (possibility ?s16-coef))
    (hero (id t3) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr74)))
    ?h <- (hero (id t3))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s16-coef) 0.4))))
    (assert (already-increased (id hr74)))
)

(defrule r75f
    (declare (salience 99))
    (trait (id s30) (possibility ?s30-coef))
    (not (hero (id t3)))
    =>
    (assert (hero (id t3) (name "Железный человек") (count 1) (possibility (* (min 1 ?s30-coef) 0.7))))
)

(defrule r75
    (declare (salience 99))
    (trait (id s30) (possibility ?s30-coef))
    (hero (id t3) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr75)))
    ?h <- (hero (id t3))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s30-coef) 0.7))))
    (assert (already-increased (id hr75)))
)

(defrule r76f
    (declare (salience 99))
    (trait (id s8) (possibility ?s8-coef))
    (not (hero (id t4)))
    =>
    (assert (hero (id t4) (name "Профессор Х") (count 1) (possibility (* (min 1 ?s8-coef) 0.9))))
)

(defrule r76
    (declare (salience 99))
    (trait (id s8) (possibility ?s8-coef))
    (hero (id t4) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr76)))
    ?h <- (hero (id t4))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s8-coef) 0.9))))
    (assert (already-increased (id hr76)))
)

(defrule r77f
    (declare (salience 99))
    (trait (id s12) (possibility ?s12-coef))
    (not (hero (id t5)))
    =>
    (assert (hero (id t5) (name "Росомаха") (count 1) (possibility (* (min 1 ?s12-coef) 0.8))))
)

(defrule r77
    (declare (salience 99))
    (trait (id s12) (possibility ?s12-coef))
    (hero (id t5) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr77)))
    ?h <- (hero (id t5))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s12-coef) 0.8))))
    (assert (already-increased (id hr77)))
)

(defrule r78f
    (declare (salience 99))
    (trait (id s14) (possibility ?s14-coef))
    (not (hero (id t5)))
    =>
    (assert (hero (id t5) (name "Росомаха") (count 1) (possibility (* (min 1 ?s14-coef) 0.85))))
)

(defrule r78
    (declare (salience 99))
    (trait (id s14) (possibility ?s14-coef))
    (hero (id t5) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr78)))
    ?h <- (hero (id t5))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s14-coef) 0.85))))
    (assert (already-increased (id hr78)))
)

(defrule r79f
    (declare (salience 99))
    (trait (id s28) (possibility ?s28-coef))
    (not (hero (id t5)))
    =>
    (assert (hero (id t5) (name "Росомаха") (count 1) (possibility (* (min 1 ?s28-coef) 0.6))))
)

(defrule r79
    (declare (salience 99))
    (trait (id s28) (possibility ?s28-coef))
    (hero (id t5) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr79)))
    ?h <- (hero (id t5))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s28-coef) 0.6))))
    (assert (already-increased (id hr79)))
)

(defrule r80f
    (declare (salience 99))
    (trait (id s18) (possibility ?s18-coef))
    (not (hero (id t6)))
    =>
    (assert (hero (id t6) (name "Человек-Паук") (count 1) (possibility (* (min 1 ?s18-coef) 0.75))))
)

(defrule r80
    (declare (salience 99))
    (trait (id s18) (possibility ?s18-coef))
    (hero (id t6) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr80)))
    ?h <- (hero (id t6))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s18-coef) 0.75))))
    (assert (already-increased (id hr80)))
)

(defrule r81f
    (declare (salience 99))
    (trait (id s28) (possibility ?s28-coef))
    (not (hero (id t6)))
    =>
    (assert (hero (id t6) (name "Человек-Паук") (count 1) (possibility (* (min 1 ?s28-coef) 0.6))))
)

(defrule r81
    (declare (salience 99))
    (trait (id s28) (possibility ?s28-coef))
    (hero (id t6) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr81)))
    ?h <- (hero (id t6))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s28-coef) 0.6))))
    (assert (already-increased (id hr81)))
)

(defrule r82f
    (declare (salience 99))
    (trait (id s30) (possibility ?s30-coef))
    (not (hero (id t6)))
    =>
    (assert (hero (id t6) (name "Человек-Паук") (count 1) (possibility (* (min 1 ?s30-coef) 0.4))))
)

(defrule r82
    (declare (salience 99))
    (trait (id s30) (possibility ?s30-coef))
    (hero (id t6) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr82)))
    ?h <- (hero (id t6))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s30-coef) 0.4))))
    (assert (already-increased (id hr82)))
)

(defrule r83f
    (declare (salience 99))
    (trait (id s10) (possibility ?s10-coef))
    (not (hero (id t7)))
    =>
    (assert (hero (id t7) (name "Халк") (count 1) (possibility (* (min 1 ?s10-coef) 0.8))))
)

(defrule r83
    (declare (salience 99))
    (trait (id s10) (possibility ?s10-coef))
    (hero (id t7) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr83)))
    ?h <- (hero (id t7))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s10-coef) 0.8))))
    (assert (already-increased (id hr83)))
)

(defrule r84f
    (declare (salience 99))
    (trait (id s12) (possibility ?s12-coef))
    (not (hero (id t7)))
    =>
    (assert (hero (id t7) (name "Халк") (count 1) (possibility (* (min 1 ?s12-coef) 0.9))))
)

(defrule r84
    (declare (salience 99))
    (trait (id s12) (possibility ?s12-coef))
    (hero (id t7) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr84)))
    ?h <- (hero (id t7))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s12-coef) 0.9))))
    (assert (already-increased (id hr84)))
)

(defrule r85f
    (declare (salience 99))
    (trait (id s14) (possibility ?s14-coef))
    (not (hero (id t7)))
    =>
    (assert (hero (id t7) (name "Халк") (count 1) (possibility (* (min 1 ?s14-coef) 0.85))))
)

(defrule r85
    (declare (salience 99))
    (trait (id s14) (possibility ?s14-coef))
    (hero (id t7) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr85)))
    ?h <- (hero (id t7))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s14-coef) 0.85))))
    (assert (already-increased (id hr85)))
)

(defrule r86f
    (declare (salience 99))
    (trait (id s10) (possibility ?s10-coef))
    (not (hero (id t8)))
    =>
    (assert (hero (id t8) (name "Ртуть") (count 1) (possibility (* (min 1 ?s10-coef) 0.9))))
)

(defrule r86
    (declare (salience 99))
    (trait (id s10) (possibility ?s10-coef))
    (hero (id t8) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr86)))
    ?h <- (hero (id t8))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s10-coef) 0.9))))
    (assert (already-increased (id hr86)))
)

(defrule r87f
    (declare (salience 99))
    (trait (id s18) (possibility ?s18-coef))
    (not (hero (id t8)))
    =>
    (assert (hero (id t8) (name "Ртуть") (count 1) (possibility (* (min 1 ?s18-coef) 0.85))))
)

(defrule r87
    (declare (salience 99))
    (trait (id s18) (possibility ?s18-coef))
    (hero (id t8) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr87)))
    ?h <- (hero (id t8))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s18-coef) 0.85))))
    (assert (already-increased (id hr87)))
)

(defrule r88f
    (declare (salience 99))
    (trait (id s20) (possibility ?s20-coef))
    (not (hero (id t8)))
    =>
    (assert (hero (id t8) (name "Ртуть") (count 1) (possibility (* (min 1 ?s20-coef) 0.95))))
)

(defrule r88
    (declare (salience 99))
    (trait (id s20) (possibility ?s20-coef))
    (hero (id t8) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr88)))
    ?h <- (hero (id t8))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s20-coef) 0.95))))
    (assert (already-increased (id hr88)))
)

(defrule r89f
    (declare (salience 99))
    (trait (id s8) (possibility ?s8-coef))
    (not (hero (id t9)))
    =>
    (assert (hero (id t9) (name "Доктор Стрэндж") (count 1) (possibility (* (min 1 ?s8-coef) 0.7))))
)

(defrule r89
    (declare (salience 99))
    (trait (id s8) (possibility ?s8-coef))
    (hero (id t9) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr89)))
    ?h <- (hero (id t9))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s8-coef) 0.7))))
    (assert (already-increased (id hr89)))
)

(defrule r90f
    (declare (salience 99))
    (trait (id s14) (possibility ?s14-coef))
    (not (hero (id t9)))
    =>
    (assert (hero (id t9) (name "Доктор Стрэндж") (count 1) (possibility (* (min 1 ?s14-coef) 0.6))))
)

(defrule r90
    (declare (salience 99))
    (trait (id s14) (possibility ?s14-coef))
    (hero (id t9) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr90)))
    ?h <- (hero (id t9))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s14-coef) 0.6))))
    (assert (already-increased (id hr90)))
)

(defrule r91f
    (declare (salience 99))
    (trait (id s16) (possibility ?s16-coef))
    (not (hero (id t9)))
    =>
    (assert (hero (id t9) (name "Доктор Стрэндж") (count 1) (possibility (* (min 1 ?s16-coef) 0.5))))
)

(defrule r91
    (declare (salience 99))
    (trait (id s16) (possibility ?s16-coef))
    (hero (id t9) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr91)))
    ?h <- (hero (id t9))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s16-coef) 0.5))))
    (assert (already-increased (id hr91)))
)

(defrule r92f
    (declare (salience 99))
    (trait (id s22) (possibility ?s22-coef))
    (not (hero (id t9)))
    =>
    (assert (hero (id t9) (name "Доктор Стрэндж") (count 1) (possibility (* (min 1 ?s22-coef) 0.4))))
)

(defrule r92
    (declare (salience 99))
    (trait (id s22) (possibility ?s22-coef))
    (hero (id t9) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr92)))
    ?h <- (hero (id t9))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s22-coef) 0.4))))
    (assert (already-increased (id hr92)))
)

(defrule r93f
    (declare (salience 99))
    (trait (id s24) (possibility ?s24-coef))
    (not (hero (id t9)))
    =>
    (assert (hero (id t9) (name "Доктор Стрэндж") (count 1) (possibility (* (min 1 ?s24-coef) 0.9))))
)

(defrule r93
    (declare (salience 99))
    (trait (id s24) (possibility ?s24-coef))
    (hero (id t9) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr93)))
    ?h <- (hero (id t9))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s24-coef) 0.9))))
    (assert (already-increased (id hr93)))
)

(defrule r94f
    (declare (salience 99))
    (trait (id s28) (possibility ?s28-coef))
    (not (hero (id t9)))
    =>
    (assert (hero (id t9) (name "Доктор Стрэндж") (count 1) (possibility (* (min 1 ?s28-coef) 0.3))))
)

(defrule r94
    (declare (salience 99))
    (trait (id s28) (possibility ?s28-coef))
    (hero (id t9) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr94)))
    ?h <- (hero (id t9))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s28-coef) 0.3))))
    (assert (already-increased (id hr94)))
)

(defrule r95f
    (declare (salience 99))
    (trait (id s8) (possibility ?s8-coef))
    (not (hero (id t10)))
    =>
    (assert (hero (id t10) (name "Алая Ведьма") (count 1) (possibility (* (min 1 ?s8-coef) 0.7))))
)

(defrule r95
    (declare (salience 99))
    (trait (id s8) (possibility ?s8-coef))
    (hero (id t10) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr95)))
    ?h <- (hero (id t10))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s8-coef) 0.7))))
    (assert (already-increased (id hr95)))
)

(defrule r96f
    (declare (salience 99))
    (trait (id s16) (possibility ?s16-coef))
    (not (hero (id t10)))
    =>
    (assert (hero (id t10) (name "Алая Ведьма") (count 1) (possibility (* (min 1 ?s16-coef) 0.6))))
)

(defrule r96
    (declare (salience 99))
    (trait (id s16) (possibility ?s16-coef))
    (hero (id t10) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr96)))
    ?h <- (hero (id t10))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s16-coef) 0.6))))
    (assert (already-increased (id hr96)))
)

(defrule r97f
    (declare (salience 99))
    (trait (id s22) (possibility ?s22-coef))
    (not (hero (id t10)))
    =>
    (assert (hero (id t10) (name "Алая Ведьма") (count 1) (possibility (* (min 1 ?s22-coef) 0.4))))
)

(defrule r97
    (declare (salience 99))
    (trait (id s22) (possibility ?s22-coef))
    (hero (id t10) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr97)))
    ?h <- (hero (id t10))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s22-coef) 0.4))))
    (assert (already-increased (id hr97)))
)

(defrule r98f
    (declare (salience 99))
    (trait (id s24) (possibility ?s24-coef))
    (not (hero (id t10)))
    =>
    (assert (hero (id t10) (name "Алая Ведьма") (count 1) (possibility (* (min 1 ?s24-coef) 0.75))))
)

(defrule r98
    (declare (salience 99))
    (trait (id s24) (possibility ?s24-coef))
    (hero (id t10) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr98)))
    ?h <- (hero (id t10))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s24-coef) 0.75))))
    (assert (already-increased (id hr98)))
)

(defrule r99f
    (declare (salience 99))
    (trait (id s18) (possibility ?s18-coef))
    (not (hero (id t11)))
    =>
    (assert (hero (id t11) (name "Сорвиголова") (count 1) (possibility (* (min 1 ?s18-coef) 0.85))))
)

(defrule r99
    (declare (salience 99))
    (trait (id s18) (possibility ?s18-coef))
    (hero (id t11) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr99)))
    ?h <- (hero (id t11))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s18-coef) 0.85))))
    (assert (already-increased (id hr99)))
)

(defrule r100f
    (declare (salience 99))
    (trait (id s28) (possibility ?s28-coef))
    (not (hero (id t11)))
    =>
    (assert (hero (id t11) (name "Сорвиголова") (count 1) (possibility (* (min 1 ?s28-coef) 0.9))))
)

(defrule r100
    (declare (salience 99))
    (trait (id s28) (possibility ?s28-coef))
    (hero (id t11) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr100)))
    ?h <- (hero (id t11))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s28-coef) 0.9))))
    (assert (already-increased (id hr100)))
)

(defrule r101f
    (declare (salience 99))
    (trait (id s12) (possibility ?s12-coef))
    (not (hero (id t12)))
    =>
    (assert (hero (id t12) (name "Капитан Америка") (count 1) (possibility (* (min 1 ?s12-coef) 0.85))))
)

(defrule r101
    (declare (salience 99))
    (trait (id s12) (possibility ?s12-coef))
    (hero (id t12) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr101)))
    ?h <- (hero (id t12))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s12-coef) 0.85))))
    (assert (already-increased (id hr101)))
)

(defrule r102f
    (declare (salience 99))
    (trait (id s18) (possibility ?s18-coef))
    (not (hero (id t12)))
    =>
    (assert (hero (id t12) (name "Капитан Америка") (count 1) (possibility (* (min 1 ?s18-coef) 0.7))))
)

(defrule r102
    (declare (salience 99))
    (trait (id s18) (possibility ?s18-coef))
    (hero (id t12) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr102)))
    ?h <- (hero (id t12))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s18-coef) 0.7))))
    (assert (already-increased (id hr102)))
)

(defrule r103f
    (declare (salience 99))
    (trait (id s20) (possibility ?s20-coef))
    (not (hero (id t12)))
    =>
    (assert (hero (id t12) (name "Капитан Америка") (count 1) (possibility (* (min 1 ?s20-coef) 0.3))))
)

(defrule r103
    (declare (salience 99))
    (trait (id s20) (possibility ?s20-coef))
    (hero (id t12) (count ?cnt) (possibility ?old-coef))
    (not (already-increased (id hr103)))
    ?h <- (hero (id t12))
    =>
    (modify ?h (count (+ ?cnt 1)) (possibility (max ?old-coef (* (min 1 ?s20-coef) 0.3))))
    (assert (already-increased (id hr103)))
)

(defrule r104f
    (declare (salience 99))
    (trait (id s5) (possibility ?s5-coef))
    (not (trait (id s8)))
    =>
    (assert (trait (id s8) (name "Телепатия (герой)") (possibility (* (min 1 ?s5-coef) 0.7))))
)

(defrule r104
    (declare (salience 99))
    (trait (id s5) (possibility ?s5-coef))
    (trait (id s8) (possibility ?old-coef))
    (not (already-increased (id tr104)))
    ?t <- (trait (id s8))
    =>
    (modify ?t (possibility (max ?old-coef (* (min 1 ?s5-coef) 0.7))))
    (assert (already-increased (id tr104)))
)

