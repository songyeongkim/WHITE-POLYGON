using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Function
{
    //! 게임 객체를 생성한다.
    public static GameObject CreateGameObject(string a_oName, GameObject a_oParent, bool a_bIsStayWorldState = false)
    {
        var oGameObject = new GameObject(a_oName);
        oGameObject.transform.SetParent(a_oParent?.transform, a_bIsStayWorldState);
        return oGameObject;
    }

    //! 컴포넌트를 탐색한다.
    public static T FindComponent<T>(string a_oName) where T : Component
    {
        var oGameObject = GameObject.Find(a_oName);
        return oGameObject?.GetComponentInChildren<T>();
    }

    //! 컴포넌트를 추가한다.
    public static T AddComponent<T>(GameObject a_oGameObject) where T : Component
    {
        var oComponent = a_oGameObject.GetComponent<T>();

        if(oComponent == null)
        {
            oComponent = a_oGameObject.AddComponent<T>();
        }

        return oComponent;
    }

    //! 비동기 작업을 대기한다.
    public static IEnumerator WaitAsyncOperation(AsyncOperation a_oAsyncOperation, System.Action<AsyncOperation> a_oCallBack)
    {
        while(!a_oAsyncOperation.isDone)
        {
            yield return new WaitForEndOfFrame();
            a_oCallBack?.Invoke(a_oAsyncOperation);
        }
    }

    //! 함수를 지연 호출한다.
    private static IEnumerator DoLateCall(System.Action<object[]> a_oCallBack, float a_fDelay, object[] a_oParam)
    {
        yield return new WaitForSeconds(a_fDelay);
        a_oCallBack?.Invoke(a_oParam);
    }
}


/*
 
 게임적인 구성

 애니메이션을 좀 더 다룰 수 있어야 한다.
 - 연출적인 부분에서 활용하기, 타임라인 - 비주얼노벨류에서 많이 쓰임

UI쪽에 힘을 많이 실어야 함. 게임의 생동감 - 흔들리거나 움직이거나 하는 버튼 동적으로 보이는 것
ㄴ UGUI 써야 한다. (NGUI는 구매해야 함)

사운드
ㄴ FMOD - 라이브러리 집합


파일 시스템
ㄴ JSON - 이 프로젝트에는 이게 좀 더 적합 , XML

이펙트 + 파티클
ㄴ 화이팅.....

옵션:
ㄴ INI - 게임 설정값

스테이지:
ㄴ 줄이고 랜덤 요소...?나 시간 제약 등의 플레이 방해하는 요소 -> 긴박감.아이템을 통한 해결.
아이템 사용 힌트 -> 시각적으로 보여주거나 텍스트로 설명
힌트 아이템

상점:
ㄴ 중요한 기능.... 상점처럼 보이는 그 무언가....

플레이어:
ㄴ 이벤트 씬 처리
개연성....이 필요하다. 오프닝에서 개연성에 대한 밑밥이 필요. 엔딩이 뜬금없이 느껴지지 않도록


 플레이어, 도형, 스테이지, 이펙트 + 파티클, 파일 시스템, UI + 사운드,  이템, 상점



 */