;========================================================================
; Этот блок реализует логику обмена информацией с графической оболочкой,
; а также механизм остановки и повторного пуска машины вывода
; Русский текст в комментариях разрешён!

(deftemplate ioproxy  ; шаблон факта-посредника для обмена информацией с GUI
	(multislot messages)  ; исходящие сообщения
)

; Собственно экземпляр факта ioproxy
(deffacts proxy-fact
	(ioproxy
		(messages)     ; мультислот messages изначально пуст
	)
)

(defrule append-output-and-proceed
	(declare (salience 99))
	?current-message <- (appendmessage ?new-msg)
	?proxy <- (ioproxy (messages $?msg-list))
	=>
	(modify ?proxy (messages $?msg-list ?new-msg))
	(retract ?current-message)
)

(deftemplate hero
    (slot id)
    (slot name)
	(slot count)
)

(deftemplate trait
    (slot id)
    (slot name)
)

(deftemplate already-increased
	(slot id)
)

(deftemplate team-size
	(slot count)
)