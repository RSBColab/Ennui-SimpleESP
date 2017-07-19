using Ennui.Api;
using Ennui.Api.Script;

namespace SimpleESP
{
    [LocalScript]
    public class ESPScript: StateScript
    {
        private Configuration _configuration;
        private Timer _timer;

        public override bool OnStart(IScriptEngine se)
        {
            _configuration = new Configuration();
            _timer = new Timer();

            Logging.Log("Load ESP Script", LogLevel.Info);

            AddState("config", new ConfigState(_configuration));
            AddState("work", new WorkState(_configuration));
            EnterState("config");

            return base.OnStart(se);
        }

        
    }
}
