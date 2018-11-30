defrule r1
    (villain (id f1))
    =>
    (assert (trait (name Телепатия (враг)) (id s7))
)

defrule r2
    (villain (id f1))
    =>
    (assert (trait (name Сверхсила (враг)) (id s11))
)

defrule r3
    (villain (id f1))
    =>
    (assert (trait (name Неуязвимость (враг)) (id s13))
)

defrule r4
    (villain (id f1))
    =>
    (assert (trait (name Левитация (враг)) (id s15))
)

defrule r5
    (villain (id f2))
    =>
    (assert (trait (name Телепатия (враг)) (id s7))
)

defrule r6
    (villain (id f2))
    =>
    (assert (trait (name Устойчивость к телепатии (враг)) (id s9))
)

defrule r7
    (villain (id f2))
    =>
    (assert (trait (name Левитация (враг)) (id s15))
)

defrule r8
    (villain (id f3))
    =>
    (assert (trait (name Телепатия (враг)) (id s7))
)

defrule r9
    (villain (id f3))
    =>
    (assert (trait (name Сверхсила (враг)) (id s11))
)

defrule r10
    (villain (id f3))
    =>
    (assert (trait (name Неуязвимость (враг)) (id s13))
)

defrule r11
    (villain (id f3))
    =>
    (assert (trait (name Ловкость (враг)) (id s17))
)

defrule r12
    (villain (id f3))
    =>
    (assert (trait (name Магия (враг)) (id s23))
)

defrule r13
    (villain (id f3))
    =>
    (assert (trait (name Шпионаж (враг)) (id s25))
)

defrule r14
    (villain (id f4))
    =>
    (assert (trait (name Устойчивость к телепатии (враг)) (id s9))
)

defrule r15
    (villain (id f4))
    =>
    (assert (trait (name Ловкость (враг)) (id s17))
)

defrule r16
    (villain (id f4))
    =>
    (assert (trait (name Шпионаж (враг)) (id s25))
)

defrule r17
    (villain (id f4))
    =>
    (assert (trait (name Боевые искусства (враг)) (id s27))
)

defrule r18
    (villain (id f5))
    =>
    (assert (trait (name Телепатия (враг)) (id s7))
)

defrule r19
    (villain (id f5))
    =>
    (assert (trait (name Сверхсила (враг)) (id s11))
)

defrule r20
    (villain (id f5))
    =>
    (assert (trait (name Ловкость (враг)) (id s17))
)

defrule r21
    (villain (id f5))
    =>
    (assert (trait (name Сверхскорость (враг)) (id s19))
)

defrule r22
    (villain (id f5))
    =>
    (assert (trait (name Магия (враг)) (id s23))
)

defrule r23
    (villain (id f6))
    =>
    (assert (trait (name Неуязвимость (враг)) (id s13))
)

defrule r24
    (villain (id f6))
    =>
    (assert (trait (name Телепатия (враг)) (id s7))
)

defrule r25
    (villain (id f6))
    =>
    (assert (trait (name Сверхсила (враг)) (id s11))
)

defrule r26
    (villain (id f6))
    =>
    (assert (trait (name Левитация (враг)) (id s15))
)

defrule r27
    (villain (id f6))
    =>
    (assert (trait (name Боевые искусства (враг)) (id s27))
)

defrule r28
    (villain (id f6))
    =>
    (assert (trait (name Магия (враг)) (id s23))
)

defrule r29
    (villain (id f7))
    =>
    (assert (trait (name Сверхсила (враг)) (id s11))
)

defrule r30
    (villain (id f8))
    =>
    (assert (trait (name Сверхсила (враг)) (id s11))
)

defrule r31
    (villain (id f8))
    =>
    (assert (trait (name Ловкость (враг)) (id s17))
)

defrule r32
    (villain (id f8))
    =>
    (assert (trait (name Сверхскорость (враг)) (id s19))
)

defrule r33
    (villain (id f8))
    =>
    (assert (trait (name Шпионаж (враг)) (id s25))
)

defrule r34
    (villain (id f8))
    =>
    (assert (trait (name Боевые искусства (враг)) (id s27))
)

defrule r35
    (villain (id f9))
    =>
    (assert (trait (name Сверхсила (враг)) (id s11))
)

defrule r36
    (villain (id f9))
    =>
    (assert (trait (name Ловкость (враг)) (id s17))
)

defrule r37
    (villain (id f9))
    =>
    (assert (trait (name Сверхскорость (враг)) (id s19))
)

defrule r38
    (villain (id f9))
    =>
    (assert (trait (name Шпионаж (враг)) (id s25))
)

defrule r39
    (villain (id f10))
    =>
    (assert (trait (name Сверхсила (враг)) (id s11))
)

defrule r40
    (villain (id f10))
    =>
    (assert (trait (name Ловкость (враг)) (id s17))
)

defrule r41
    (villain (id f11))
    =>
    (assert (trait (name Сверхсила (враг)) (id s11))
)

defrule r42
    (villain (id f11))
    =>
    (assert (trait (name Левитация (враг)) (id s15))
)

defrule r43
    (villain (id f11))
    =>
    (assert (trait (name Сверхскорость (враг)) (id s19))
)

defrule r44
    (villain (id f12))
    =>
    (assert (trait (name Сверхсила (враг)) (id s11))
)

defrule r45
    (villain (id f12))
    =>
    (assert (trait (name Ловкость (враг)) (id s17))
)

defrule r46
    (trait (id s7))
    (trait (id s11))
    (trait (id s13))
    (trait (id s15))
    =>
    (assert (trait (name Имбовый класс) (id s1))
)

defrule r47
    (trait (id s11))
    (trait (id s13))
    =>
    (assert (trait (name Класс Танк) (id s2))
)

defrule r48
    (trait (id s17))
    (trait (id s25))
    =>
    (assert (trait (name Класс Син (Убийца)) (id s3))
)

defrule r49
    (trait (id s11))
    =>
    (assert (trait (name Ближний бой) (id s4))
)

defrule r50
    (trait (id s27))
    =>
    (assert (trait (name Ближний бой) (id s4))
)

defrule r51
    (trait (id s29))
    =>
    (assert (trait (name Дальний бой) (id s5))
)

defrule r52
    (trait (id s23))
    =>
    (assert (trait (name Дальний бой) (id s5))
)

defrule r53
    (trait (id s21))
    =>
    (assert (trait (name Поддержка) (id s6))
)

defrule r54
    (trait (id s2))
    =>
    (assert (trait (name Сверхсила (герой)) (id s12))
)

defrule r55
    (trait (id s2))
    =>
    (assert (trait (name Неуязвимость (враг)) (id s13))
)

defrule r56
    (trait (id s3))
    =>
    (assert (trait (name Магия (герой)) (id s24))
)

defrule r57
    (trait (id s3))
    =>
    (assert (trait (name Стрелок (герой)) (id s30))
)

defrule r58
    (trait (id s4))
    =>
    (assert (trait (name Неуязвимость (герой)) (id s14))
)

defrule r59
    (trait (id s4))
    =>
    (assert (trait (name Боевые искусства (герой)) (id s28))
)

defrule r60
    (trait (id s5))
    =>
    (assert (trait (name Ловкость (герой)) (id s18))
)

defrule r61
    (trait (id s6))
    =>
    (assert (trait (name Сверхсила (герой)) (id s12))
)

defrule r62
    (trait (id s7))
    =>
    (assert (trait (name Устойчивость к телепатии (герой)) (id s10))
)

defrule r63
    (trait (id s9))
    =>
    (assert (trait (name Магия (герой)) (id s24))
)

defrule r64
    (trait (id s17))
    =>
    (assert (trait (name Сверхскорость (герой)) (id s20))
)

defrule r65
    (trait (id s21))
    =>
    (assert (trait (name Шпионаж (герой)) (id s26))
)

defrule r66
    (trait (id s23))
    =>
    (assert (trait (name Защитное поле (герой)) (id s22))
)

defrule r67
    (trait (id s1))
    =>
    (assert (hero (name Капитан Марвел) (id t1))
)

defrule r68
    (trait (id s12))
    =>
    (assert (hero (name Капитан Марвел) (id t1))
)

defrule r69
    (trait (id s14))
    =>
    (assert (hero (name Капитан Марвел) (id t1))
)

defrule r70
    (trait (id s16))
    =>
    (assert (hero (name Капитан Марвел) (id t1))
)

defrule r71
    (trait (id s12))
    =>
    (assert (hero (name Тор) (id t2))
)

defrule r72
    (trait (id s16))
    =>
    (assert (hero (name Тор) (id t2))
)

defrule r73
    (trait (id s24))
    =>
    (assert (hero (name Тор) (id t2))
)

defrule r74
    (trait (id s16))
    =>
    (assert (hero (name Железный человек) (id t3))
)

defrule r75
    (trait (id s30))
    =>
    (assert (hero (name Железный человек) (id t3))
)

defrule r76
    (trait (id s8))
    =>
    (assert (hero (name Профессор Х) (id t4))
)

defrule r77
    (trait (id s12))
    =>
    (assert (hero (name Росомаха) (id t5))
)

defrule r78
    (trait (id s14))
    =>
    (assert (hero (name Росомаха) (id t5))
)

defrule r79
    (trait (id s28))
    =>
    (assert (hero (name Росомаха) (id t5))
)

defrule r80
    (trait (id s18))
    =>
    (assert (hero (name Человек-Паук) (id t6))
)

defrule r81
    (trait (id s28))
    =>
    (assert (hero (name Человек-Паук) (id t6))
)

defrule r82
    (trait (id s30))
    =>
    (assert (hero (name Человек-Паук) (id t6))
)

defrule r83
    (trait (id s10))
    =>
    (assert (hero (name Халк) (id t7))
)

defrule r84
    (trait (id s12))
    =>
    (assert (hero (name Халк) (id t7))
)

defrule r85
    (trait (id s14))
    =>
    (assert (hero (name Халк) (id t7))
)

defrule r86
    (trait (id s10))
    =>
    (assert (hero (name Ртуть) (id t8))
)

defrule r87
    (trait (id s18))
    =>
    (assert (hero (name Ртуть) (id t8))
)

defrule r88
    (trait (id s20))
    =>
    (assert (hero (name Ртуть) (id t8))
)

defrule r89
    (trait (id s8))
    =>
    (assert (hero (name Доктор Стрэндж) (id t9))
)

defrule r90
    (trait (id s14))
    =>
    (assert (hero (name Доктор Стрэндж) (id t9))
)

defrule r91
    (trait (id s16))
    =>
    (assert (hero (name Доктор Стрэндж) (id t9))
)

defrule r92
    (trait (id s22))
    =>
    (assert (hero (name Доктор Стрэндж) (id t9))
)

defrule r93
    (trait (id s24))
    =>
    (assert (hero (name Доктор Стрэндж) (id t9))
)

defrule r94
    (trait (id s28))
    =>
    (assert (hero (name Доктор Стрэндж) (id t9))
)

defrule r95
    (trait (id s8))
    =>
    (assert (hero (name Алая Ведьма) (id t10))
)

defrule r96
    (trait (id s16))
    =>
    (assert (hero (name Алая Ведьма) (id t10))
)

defrule r97
    (trait (id s22))
    =>
    (assert (hero (name Алая Ведьма) (id t10))
)

defrule r98
    (trait (id s24))
    =>
    (assert (hero (name Алая Ведьма) (id t10))
)

defrule r99
    (trait (id s18))
    =>
    (assert (hero (name Сорвиголова) (id t11))
)

defrule r100
    (trait (id s28))
    =>
    (assert (hero (name Сорвиголова) (id t11))
)

defrule r101
    (trait (id s12))
    =>
    (assert (hero (name Капитан Америка) (id t12))
)

defrule r102
    (trait (id s18))
    =>
    (assert (hero (name Капитан Америка) (id t12))
)

defrule r103
    (trait (id s20))
    =>
    (assert (hero (name Капитан Америка) (id t12))
)

defrule r104
    (trait (id s5))
    =>
    (assert (trait (name Телепатия (герой)) (id s8))
)

